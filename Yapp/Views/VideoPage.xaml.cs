using System;

using Windows.UI.Xaml.Controls;

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
    }
}