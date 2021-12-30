using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Refit;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Poutinio.Core.Services;
using Poutinio.Services;
using Poutinio.Core.ViewModels;
using Poutinio.Core.Models;

namespace Poutinio
{
    public sealed partial class App : Application
    {
        private readonly string PutIoHost = "https://api.put.io/v2/";
        private readonly RefitSettings RefitSettings = new RefitSettings()
        { 
            AuthorizationHeaderValueGetter = () => Task.FromResult(Ioc.Default.GetRequiredService<ISettingsService>().GetToken())
        };

        private Lazy<ActivationService> _activationService;

        private ActivationService ActivationService => _activationService.Value;

        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                .AddSingleton<INavigationService, NavigationService>()
                .AddSingleton<ISettingsService, SettingsService>()
                .AddSingleton(RestService.For<IPutIoService>(PutIoHost, RefitSettings))
                .AddTransient<LoginViewModel>()
                .AddTransient<ExplorerViewModel>()
                .AddTransient<PlayerViewModel>()
                .BuildServiceProvider());

            InitializeComponent();

            _activationService = new Lazy<ActivationService>(CreateActivationService);
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (!args.PrelaunchActivated)
            {
                await ActivationService.ActivateAsync(args);
            }
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            await ActivationService.ActivateAsync(args);
        }

        private ActivationService CreateActivationService()
        {
            return new ActivationService(this, NavigationKind.Login, new Lazy<UIElement>(CreateShell));
        }

        private UIElement CreateShell()
        {
            return new Views.ShellPage();
        }
    }
}
