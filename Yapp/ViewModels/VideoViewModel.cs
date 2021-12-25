using System;
using System.Windows.Input;

using LibVLCSharp.Platforms.UWP;
using LibVLCSharp.Shared;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace Yapp.ViewModels
{
    public class VideoViewModel : ObservableObject
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;
        private ICommand _initializedCommand;

        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set => SetProperty(ref _mediaPlayer, value);
        }

        public ICommand InitializedCommand => _initializedCommand ?? (_initializedCommand = new RelayCommand<InitializedEventArgs>(OnInitialized));

        public VideoViewModel()
        {
        }

        ~VideoViewModel()
        {
            Dispose();
        }

        private void OnInitialized(InitializedEventArgs eventArgs)
        {
            _libVLC = new LibVLC(enableDebugLogs: true, eventArgs.SwapChainOptions);
            MediaPlayer = new MediaPlayer(_libVLC);

            using var media = new Media(_libVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
            MediaPlayer.Play(media);
        }

        public void Dispose()
        {
            var mediaPlayer = MediaPlayer;
            MediaPlayer = null;
            mediaPlayer?.Dispose();

            _libVLC?.Dispose();
            _libVLC = null;
        }
    }
}
