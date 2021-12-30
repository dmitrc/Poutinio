namespace Poutinio.Core.Services
{
    public interface IDispatcherService
    {
        Task RunOnUiThread(Action action);
    }
}
