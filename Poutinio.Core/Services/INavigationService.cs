using Poutinio.Core.Models;

namespace Poutinio.Core.Services
{
    public interface INavigationService
    {
        bool CanGoBack { get;  }
        bool GoBack();
        bool Navigate(NavigationKind kind, object parameter = null);
        bool PopHistory();
        bool HasContent();
    }
}
