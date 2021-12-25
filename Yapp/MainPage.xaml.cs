using LibVLCSharp.Platforms.UWP;
using LibVLCSharp.Shared;
using System;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Yapp
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private LibVLC LibVLC { get; set; }

        private MediaPlayer _mediaPlayer;
        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            private set => Set(nameof(MediaPlayer), ref _mediaPlayer, value);
        }

        public MainPage()
        {
            this.InitializeComponent();

            this.Unloaded += OnUnloaded;
        }

        private void OnVideoViewInitialized(object sender, InitializedEventArgs e)
        {
            LibVLC = new LibVLC(enableDebugLogs: true, e.SwapChainOptions);
            MediaPlayer = new MediaPlayer(LibVLC);

            using var media = new Media(LibVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
            MediaPlayer.Play(media);
        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            var mediaPlayer = MediaPlayer;
            MediaPlayer = null;
            mediaPlayer?.Dispose();

            LibVLC?.Dispose();
            LibVLC = null;
        }

        private void Set<T>(string propertyName, ref T field, T value)
        {
            if (field == null && value != null || field != null && !field.Equals(value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}