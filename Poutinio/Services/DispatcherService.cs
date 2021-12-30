using Poutinio.Core.Services;
using System;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace Poutinio.Services
{
    public class DispatcherService : IDispatcherService
    {
        private readonly CoreDispatcher _dispatcher;

        public DispatcherService()
        {
            _dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
        }

        public async Task RunOnUiThread(Action action)
        {
            await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, new DispatchedHandler(action));
        }
    }
}
