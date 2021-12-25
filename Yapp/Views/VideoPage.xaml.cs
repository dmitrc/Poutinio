using System;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using Yapp.ViewModels;

namespace Yapp.Views
{
    public sealed partial class VideoPage : Page
    {
        public VideoViewModel ViewModel { get; } = new VideoViewModel();

        public VideoPage()
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