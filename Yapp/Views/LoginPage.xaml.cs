using System;

using Windows.UI.Xaml.Controls;

using Yapp.ViewModels;

namespace Yapp.Views
{
    public sealed partial class LoginPage : Page
    {
        public LoginViewModel ViewModel { get; } = new LoginViewModel();

        public LoginPage()
        {
            InitializeComponent();
        }
    }
}
