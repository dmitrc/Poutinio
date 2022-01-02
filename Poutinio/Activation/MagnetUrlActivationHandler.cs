using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Poutinio.Core.Models;
using Poutinio.Core.Services;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;

namespace Poutinio.Activation
{
    internal class MagnetUrlActivationHandler : ActivationHandler<ProtocolActivatedEventArgs>
    {
        private INavigationService _navigationService;
        private IPutIoService _putIoService;

        public MagnetUrlActivationHandler()
        {
            _navigationService = Ioc.Default.GetRequiredService<INavigationService>();
            _putIoService = Ioc.Default.GetRequiredService<IPutIoService>();
        }

        protected override async Task HandleInternalAsync(ProtocolActivatedEventArgs args)
        {
            if (args.PreviousExecutionState != ApplicationExecutionState.Running)
            {
                _navigationService.Navigate(NavigationKind.Login, new Action(async () => await RedirectAndAddTransfer(args?.Uri)));
            }
            else
            {
                await RedirectAndAddTransfer(args?.Uri);
            }
        }

        protected override bool CanHandleInternal(ProtocolActivatedEventArgs args)
        {
            return args?.Uri?.Scheme == "magnet";
        }

        private async Task RedirectAndAddTransfer(Uri uri)
        {
            if (uri != null)
            {
                var addResponse = await Task.Run(() => _putIoService.Post__Transfers_Add(uri.ToString()));
            }

            _navigationService.Navigate(NavigationKind.Transfers);
        }
    }
}
