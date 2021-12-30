using System.Windows.Input;
using LibVLCSharp.Shared;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Poutinio.Core.Services;

namespace Poutinio.Core.ViewModels
{
    public class PlayerViewModel : ObservableObject
    {
        private readonly IDispatcherService _dispatcherService;

        private LibVLC _libVLC;

        private MediaPlayer _mediaPlayer;
        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set => SetProperty(ref _mediaPlayer, value);
        }

        private bool _isBuffering;
        public bool IsBuffering
        {
            get => _isBuffering;
            set => SetProperty(ref _isBuffering, value);
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

        private ICommand _togglePlayCommand;
        public ICommand TogglePlayCommand => _togglePlayCommand ?? (_togglePlayCommand = new RelayCommand(OnTogglePlay));


        private ICommand _jumpBackCommand;
        public ICommand JumpBackCommand => _jumpBackCommand ?? (_jumpBackCommand = new RelayCommand(OnJumpBack));


        private ICommand _jumpForwardCommand;
        public ICommand JumpForwardCommand => _jumpForwardCommand ?? (_jumpForwardCommand = new RelayCommand(OnJumpForward));


        public PlayerViewModel(IDispatcherService dispatcherService)
        {
            _dispatcherService = dispatcherService;
        }

        ~PlayerViewModel()
        {
            OnUnloaded();
        }

        public void Init(Uri uri, string[] swapChainOptions)
        {
            if (uri == null) return;

            _libVLC = new LibVLC(enableDebugLogs: true, swapChainOptions);
            using var media = new Media(_libVLC, uri);

            MediaPlayer = new MediaPlayer(media) { EnableHardwareDecoding = true };

            MediaPlayer.EncounteredError += (s, e) =>
            {
                // TODO: Implement
            };

            MediaPlayer.Paused += (s, e) =>
            {
                _dispatcherService.RunOnUiThread(() =>
                {
                    IsPlaying = false;
                });
            };

            MediaPlayer.Playing += (s, e) =>
            {
                _dispatcherService.RunOnUiThread(() =>
                {
                    IsPlaying = true;
                });
            };

            MediaPlayer.PositionChanged += (s, e) =>
            {
                _dispatcherService.RunOnUiThread(() =>
                {
                    Position = e.Position;
                });
            };

            MediaPlayer.TimeChanged += (s, e) =>
            {
                _dispatcherService.RunOnUiThread(() =>
                {
                    Time = e.Time;
                });
            };

            MediaPlayer.Buffering += (s, e) =>
            {
                _dispatcherService.RunOnUiThread(() =>
                {
                    IsBuffering = e.Cache < 100;
                });
            };

            MediaPlayer.Play();
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
