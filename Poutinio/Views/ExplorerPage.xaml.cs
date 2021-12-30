using Windows.UI.Xaml.Controls;
using Poutinio.Core.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

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
    }
}
