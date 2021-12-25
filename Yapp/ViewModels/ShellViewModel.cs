using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;

using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Yapp.Models;
using Yapp.Services;
using Yapp.Views;

namespace Yapp.ViewModels
{
    public class ShellViewModel : ObservableRecipient
    {
        private readonly IPutIoService PutIoService = Ioc.Default.GetRequiredService<IPutIoService>();
        private readonly ISettingsService SettingsService = Ioc.Default.GetRequiredService<ISettingsService>();

        private bool _needsLogin;
        private string _authCode;
        private DispatcherTimer _authPollTimer;
        private ICommand _loadedCommand;

        public bool NeedsLogin
        {
            get => _needsLogin;
            set => SetProperty(ref _needsLogin, value);
        }

        public string AuthCode
        {
            get => _authCode;
            set => SetProperty(ref _authCode, value);
        }

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

        public ShellViewModel()
        {
        }

        public void Initialize(Frame frame)
        {
            NavigationService.Frame = frame;
            NavigationService.NavigationFailed += Frame_NavigationFailed;

            var systemNavigationManager = SystemNavigationManager.GetForCurrentView();
            systemNavigationManager.BackRequested += SystemNavigationManager_BackRequested;
            systemNavigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        private async void OnLoaded()
        {
            if (!SettingsService.HasToken())
            {
                NeedsLogin = true;

                var codeResponse = await PutIoService.Get__Oauth2_Oob_Code(5430, null);
                if (!string.IsNullOrEmpty(codeResponse?.Code))
                {
                    AuthCode = codeResponse.Code;
                    StartPollingForAuthenticationToken();
                }
            }
        }
        
        private void StartPollingForAuthenticationToken()
        {
            _authPollTimer = new DispatcherTimer();
            _authPollTimer.Tick += CheckForAuthenticationToken;
            _authPollTimer.Interval = TimeSpan.FromSeconds(5);
            _authPollTimer.Start();
        }

        private async void CheckForAuthenticationToken(object sender, object e)
        {
            var tokenResponse = await PutIoService.Get__Oauth2_Oob_Code(AuthCode);
            if (!string.IsNullOrEmpty(tokenResponse?.OauthToken))
            {
                _authPollTimer?.Stop();
                _authPollTimer = null;

                SettingsService.SetToken(tokenResponse.OauthToken);
                Messenger.Send(new UserChangedMessage(), "USER");

                NeedsLogin = false;
            }
        }

        // ------ Experimental code begins ------
        //private string _authenticationCode;
        //private async void OnLoaded()
        //{
        //    if (string.IsNullOrEmpty(((App)Application.Current).PutIoToken)) {
        //        var codeResponse = await PutIoService.Get__Oauth2_Oob_Code(5430, null);
        //        if (!string.IsNullOrEmpty(codeResponse?.Code))
        //        {
        //            _authenticationCode = codeResponse.Code;
        //            StartPollingForAuthenticationToken();

        //            Debug.WriteLine($"Please input code {codeResponse.Code} on https://put.io/link");
        //        }
        //    }
        //    else
        //    {
        //        await OnAuthenticated();
        //    }
        //}

        //private DispatcherTimer _authenticationTokenTimer;
        //private void StartPollingForAuthenticationToken()
        //{
        //    _authenticationTokenTimer = new DispatcherTimer();
        //    _authenticationTokenTimer.Tick += CheckForAuthenticationToken;
        //    _authenticationTokenTimer.Interval = TimeSpan.FromSeconds(5);
        //    _authenticationTokenTimer.Start();
        //}

        //private async void CheckForAuthenticationToken(object sender, object e)
        //{
        //    var tokenResponse = await PutIoService.Get__Oauth2_Oob_Code(_authenticationCode);
        //    if (!string.IsNullOrEmpty(tokenResponse?.OauthToken))
        //    {
        //        _authenticationTokenTimer?.Stop();
        //        _authenticationTokenTimer = null;

        //        ((App)Application.Current).PutIoToken = tokenResponse.OauthToken;

        //        await OnAuthenticated();
        //    }
        //}

        //private async Task OnAuthenticated()
        //{
        //var files = await PutIoService.Get__Files_List();
        //foreach (var file in files.Files)
        //{
        //    Debug.WriteLine($"{file.Name} ({file.FileType}) [{file.Id}]");

        //    var subFiles = await PutIoService.Get__Files_List(file.Id);
        //    foreach (var subFile in subFiles.Files)
        //    {
        //        Debug.WriteLine($"--- {subFile.Name} ({subFile.FileType}) [{subFile.Id}]");
        //    }

        //    Debug.WriteLine("");
        //}

        // Playback method #1, based on download URL (works)
        //var url = await PutIoService.Get__Files_Url(900678399);
        //if (url?.Url != null)
        //{
        //    NavigationService.Navigate<VideoPage>(url.Url);
        //}
        //}
        // ------ Experimental code ends ------

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = NavigationService.GoBack();
        }

        private void Frame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw e.Exception;
        }
    }
}
