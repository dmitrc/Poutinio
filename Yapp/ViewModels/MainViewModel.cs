using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Yapp.Models;
using Yapp.Services;

namespace Yapp.ViewModels
{
    public class MainViewModel : ObservableRecipient
    {
        private readonly IPutIoService PutIoService = Ioc.Default.GetRequiredService<IPutIoService>();
        private readonly ISettingsService SettingsService = Ioc.Default.GetRequiredService<ISettingsService>();

        private TaskNotifier<Get__Files_ListResponse> _filesTask;
        private ICommand _loadedCommand;

        public Task<Get__Files_ListResponse> FilesTask
        {
            get => _filesTask;
            set => SetPropertyAndNotifyOnCompletion(ref _filesTask, value);
        }

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

        public MainViewModel()
        {
        }

        private void OnLoaded()
        {
            if (SettingsService.HasToken())
            {
                StartLoading();
            }
            else
            {
                Messenger.Register<MainViewModel, UserChangedMessage, string>(this, "USER", (r, m) => StartLoading());
            }
        }

        private void StartLoading()
        {
            if (FilesTask == null)
            {
                FilesTask = PutIoService.Get__Files_List();
            }
        }
    }
}
