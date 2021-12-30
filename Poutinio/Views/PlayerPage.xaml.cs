using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Poutinio.Core.ViewModels;
using LibVLCSharp.Platforms.UWP;
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace Poutinio.Views
{
    public sealed partial class PlayerPage : Page
    {
        private Uri _uri;

        public PlayerViewModel ViewModel { get; } = Ioc.Default.GetService<PlayerViewModel>();

        public PlayerPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _uri = e.Parameter as Uri;
        }

        private void OnInitialized(object sender, InitializedEventArgs e)
        {
            ViewModel.Init(_uri, e.SwapChainOptions);
        }
    }
}