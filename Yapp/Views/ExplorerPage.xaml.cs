using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Yapp.ViewModels;

namespace Yapp.Views
{
    public sealed partial class ExplorerPage : Page
    {
        public ExplorerViewModel ViewModel { get; } = new ExplorerViewModel();

        public ExplorerPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
