using System;
using System.Threading.Tasks;
using System.Windows.Input;

using LibVLCSharp.Platforms.UWP;
using LibVLCSharp.Shared;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace Yapp.ViewModels
{
    public class PlayerViewModel : ObservableObject
    {
        private LibVLC _libVLC;

        private MediaPlayer _mediaPlayer;
        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set => SetProperty(ref _mediaPlayer, value);
        }

        private Uri _fileUri;
        public Uri FileUri
        {
            get => _fileUri;
            set => SetProperty(ref _fileUri, value);
        }

        private bool _isPlaying;
        public bool IsPlaying
        {
            get => _isPlaying;
            set => SetProperty(ref _isPlaying, value);
        }

        private double _position;
        public double Position
        {
            get => _position;
            set => SetProperty(ref _position, value);
        }

        private double _time;
        public double Time
        {
            get => _time;
            set => SetProperty(ref _time, value);
        }

        private ICommand _unloadedCommand;
        public ICommand UnloadedCommand => _unloadedCommand ?? (_unloadedCommand = new RelayCommand(OnUnloaded));

        private ICommand _initializedCommand;
        public ICommand InitializedCommand => _initializedCommand ?? (_initializedCommand = new AsyncRelayCommand<InitializedEventArgs>(OnInitialized));

        private ICommand _togglePlayCommand;
        public ICommand TogglePlayCommand => _togglePlayCommand ?? (_togglePlayCommand = new RelayCommand(OnTogglePlay));


        private ICommand _jumpBackCommand;
        public ICommand JumpBackCommand => _jumpBackCommand ?? (_jumpBackCommand = new RelayCommand(OnJumpBack));


        private ICommand _jumpForwardCommand;
        public ICommand JumpForwardCommand => _jumpForwardCommand ?? (_jumpForwardCommand = new RelayCommand(OnJumpForward));


        public PlayerViewModel()
        {
        }

        private async Task OnInitialized(InitializedEventArgs eventArgs)
        {
            _libVLC = new LibVLC(enableDebugLogs: true, eventArgs.SwapChainOptions);
            MediaPlayer = new MediaPlayer(_libVLC);

            MediaPlayer.EncounteredError += (s, e) =>
            {

            };

            MediaPlayer.Paused += (s, e) =>
            {
                IsPlaying = false;
            };

            MediaPlayer.Playing += (s, e) =>
            {
                IsPlaying = true;
            };

            MediaPlayer.PositionChanged += (s, e) =>
            {
                Position = e.Position;
            };

            MediaPlayer.TimeChanged += (s, e) =>
            {
                Time = e.Time;
            };

            if (FileUri != null)
            {
                using var media = new Media(_libVLC, FileUri);

                // TODO: Untested
                if (FileUri.AbsolutePath.EndsWith(".m3u8"))
                {
                    var status = await media.Parse();
                    if (status == MediaParsedStatus.Done)
                    {
                        foreach (var subItem in media.SubItems)
                        {
                            if (subItem.Type == MediaType.Stream || subItem.Type == MediaType.File)
                            {
                                MediaPlayer.Play(subItem);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MediaPlayer.Play(media);
                }
            }
        }

        public void OnTogglePlay()
        {
            if (IsPlaying)
            {
                MediaPlayer.Pause();
            }
            else
            {
                MediaPlayer.Play();
            }
        }

        public void OnJumpBack()
        {
            MediaPlayer.Time = Math.Max(0, MediaPlayer.Time - 10000);
        }

        public void OnJumpForward()
        {
            MediaPlayer.Time += 10000;
        }

        public void OnUnloaded()
        {
            IsPlaying = false;
            Position = 0;
            Time = 0;

            var mediaPlayer = MediaPlayer;
            MediaPlayer = null;
            mediaPlayer?.Dispose();

            _libVLC?.Dispose();
            _libVLC = null;
        }
    }
}
