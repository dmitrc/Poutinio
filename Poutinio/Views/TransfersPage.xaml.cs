using Windows.UI.Xaml.Controls;
using Poutinio.Core.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace Poutinio.Views
{
    public sealed partial class TransfersPage : Page
    {
        public TransfersViewModel ViewModel { get; } = Ioc.Default.GetService<TransfersViewModel>();

        public TransfersPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
