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
        private Uri _fileUri;

        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set => SetProperty(ref _mediaPlayer, value);
        }

        public Uri FileUri
        {
            get => _fileUri;
            set => SetProperty(ref _fileUri, value);
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

            MediaPlayer.EncounteredError += MediaPlayer_EncounteredError;

            if (FileUri != null)
            {
                using var media = new Media(_libVLC, FileUri);
                MediaPlayer.Play(media);
            }
        }

        private void MediaPlayer_EncounteredError(object sender, EventArgs e)
        {
            
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
