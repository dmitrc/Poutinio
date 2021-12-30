using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Poutinio.Core.Services;
using Poutinio.Core.Models;

namespace Poutinio.Activation
{
    internal class DefaultActivationHandler : ActivationHandler<IActivatedEventArgs>
    {
        private readonly NavigationKind _navKind;
        private readonly INavigationService _navigationService;

        public DefaultActivationHandler(NavigationKind navKind)
        {
            _navKind = navKind;
            _navigationService = Ioc.Default.GetRequiredService<INavigationService>();
        }

        protected override async Task HandleInternalAsync(IActivatedEventArgs args)
        {
            // When the navigation stack isn't restored, navigate to the first page and configure
            // the new page by passing required information in the navigation parameter
            object arguments = null;
            if (args is LaunchActivatedEventArgs launchArgs)
            {
                arguments = launchArgs.Arguments;
            }

            _navigationService.Navigate(_navKind, arguments);
            await Task.CompletedTask;
        }

        protected override bool CanHandleInternal(IActivatedEventArgs args)
        {
            // None of the ActivationHandlers has handled the app activation
            return !_navigationService.HasContent();
        }
    }
}
