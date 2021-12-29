using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Windows.UI.Xaml;
using Yapp.Models;
using Yapp.Services;
using Yapp.Views;

namespace Yapp.ViewModels
{
    public class LoginViewModel : ObservableObject
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

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new AsyncRelayCommand(OnLoaded));

        public LoginViewModel()
        {
        }

        private async Task OnLoaded()
        {
            if (await VerifyLogin())
            {
                FinishLogin();
            }
            else
            {
                await StartLogin();
            }

        }

        private async Task<bool> VerifyLogin()
        {
            // TODO: First request takes bloody forever and idk why
            try
            {
                var accountResponse = await Task.Run(() => PutIoService.Get__Account_Info());
                return !string.IsNullOrEmpty(accountResponse?.Info?.Username);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task StartLogin()
        {
            NeedsLogin = true;

            var codeResponse = await Task.Run(() => PutIoService.Get__Oauth2_Oob_Code(5430, null));
            if (!string.IsNullOrEmpty(codeResponse?.Code))
            {
                AuthCode = codeResponse.Code;
                StartPollingForAuthenticationToken();
            }
        }

        private void FinishLogin()
        {
            NeedsLogin = false;

            // TODO: Resolve navigation by ViewModel
            NavigationService.Navigate<FolderPage>();

            NavigationService.Pop();
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
            var tokenResponse = await Task.Run(() => PutIoService.Get__Oauth2_Oob_Code(AuthCode));
            if (!string.IsNullOrEmpty(tokenResponse?.OauthToken))
            {
                _authPollTimer?.Stop();
                _authPollTimer = null;

                SettingsService.SetToken(tokenResponse.OauthToken);
                FinishLogin();
            }
        }
    }
}
