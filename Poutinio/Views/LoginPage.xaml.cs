using Windows.UI.Xaml.Controls;
using Poutinio.Core.ViewModels;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Windows.UI.Xaml.Navigation;
using Poutinio.Core.Models;
using System;

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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Action action)
            {
                ViewModel.Init(action);
            }
        }
    }
}
