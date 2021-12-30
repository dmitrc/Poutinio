using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Core;

namespace Poutinio.Views
{
    public sealed partial class PlayerPage : Page
    {
        private MediaSource _mediaSource;

        public PlayerPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            if (e.Parameter is Uri uri)
            {
                _mediaSource = MediaSource.CreateFromUri(uri);
                mpe.Source = _mediaSource;
            }
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            mpe.MediaPlayer.Pause();

            _mediaSource?.Dispose();
            mpe.Source = _mediaSource = null;
        }

        private MediaSource GetMediaSource(Uri uri)
        {
            return MediaSource.CreateFromUri(uri);
        }
    }
}