using System;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using Yapp.ViewModels;

namespace Yapp.Views
{
    public sealed partial class PlayerPage : Page
    {
        public PlayerViewModel ViewModel { get; } = new PlayerViewModel();

        public PlayerPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var uri = e.Parameter as Uri;
            if (uri != null)
            {
                ViewModel.FileUri = uri;
            }
        }
    }
}