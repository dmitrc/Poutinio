using Windows.UI.Xaml.Controls;
using Poutinio.Core.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml;

namespace Poutinio.Views
{
    public sealed partial class ExplorerPage : Page
    {
        public ExplorerViewModel ViewModel { get; } = Ioc.Default.GetService<ExplorerViewModel>();

        public ExplorerPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void OnPathItemLoaded(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            button?.Focus(FocusState.Programmatic);

            pathScrollViewer?.ChangeView(pathScrollViewer.ScrollableWidth, null, null);
        }
    }
}
