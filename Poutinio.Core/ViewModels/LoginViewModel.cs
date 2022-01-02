using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Poutinio.Core.Models;
using Poutinio.Core.Services;

namespace Poutinio.Core.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private readonly IPutIoService _putIoService;
        private readonly ISettingsService _settingsService;
        private readonly INavigationService _navigationService;

        private const NavigationKind _defaultNavigationKind = NavigationKind.Explorer;

        private Action _onLoginAction;
        private bool _needsLogin;
        private string _authCode;
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

        public LoginViewModel(IPutIoService putIoService, ISettingsService settingsService, INavigationService navigationService)
        {
            _putIoService = putIoService;
            _settingsService = settingsService;
            _navigationService = navigationService;
        }

        public void Init(Action onLoginAction)
        {
            _onLoginAction = onLoginAction;
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
            try
            {
                var accountResponse = await Task.Run(() => _putIoService.Get__Account_Info());
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

            var codeResponse = await Task.Run(() => _putIoService.Get__Oauth2_Oob_Code(5430, null));
            if (!string.IsNullOrEmpty(codeResponse?.Code))
            {
                AuthCode = codeResponse.Code;

                var token = await Task.Run(() => PollAuthenticationToken(CancellationToken.None));
                _settingsService.SetToken(token);

                FinishLogin();
            }
        }

        private void FinishLogin()
        {
            NeedsLogin = false;

            _navigationService.Navigate(_defaultNavigationKind);
            _navigationService.PopHistory();

            _onLoginAction?.Invoke();
        }

        private async Task<string> PollAuthenticationToken(CancellationToken ct)
        {
            while (true)
            {
                var tokenResponse = await Task.Run(() => _putIoService.Get__Oauth2_Oob_Code(AuthCode), ct);
                if (!string.IsNullOrEmpty(tokenResponse?.OauthToken))
                {
                    return tokenResponse.OauthToken;
                }

                await Task.Delay(TimeSpan.FromSeconds(5), ct);  
            }
        }
    }
}
