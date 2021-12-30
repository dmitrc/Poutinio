using Windows.UI.Xaml.Controls;
using Poutinio.Core.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace Poutinio.Views
{
    public sealed partial class LoginPage : Page
    {
        public LoginViewModel ViewModel { get; } = Ioc.Default.GetService<LoginViewModel>();

        public LoginPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
