using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;

// TODO: This is no good
using Windows.UI.Xaml.Controls;

using Yapp.Models;
using Yapp.Services;
using Yapp.Views;

namespace Yapp.ViewModels
{
    public class FolderViewModel : ObservableObject
    {
        private readonly IPutIoService PutIoService = Ioc.Default.GetRequiredService<IPutIoService>();

        private long? _parentId;
        private ObservableCollection<File> _files;
        private ICommand _loadedCommand;
        private ICommand _itemClickCommand;

        public long? ParentId
        {
            get => _parentId;
            set => SetProperty(ref _parentId, value);
        }

        public ObservableCollection<File> Files
        {
            get => _files;
            set => SetProperty(ref _files, value);
        }

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new AsyncRelayCommand(OnLoaded));

        public ICommand ItemClickCommand => _itemClickCommand ?? (_itemClickCommand = new AsyncRelayCommand<ItemClickEventArgs>(OnItemClick));

        public FolderViewModel()
        {
        }

        private async Task OnLoaded()
        {
            var files = await Task.Run(() => PutIoService.Get__Files_List(ParentId));
            if ((files?.Files?.Length ?? 0) > 0)
            {
                Files = new ObservableCollection<File>(files.Files);
            }
        }

        private async Task OnItemClick(ItemClickEventArgs e)
        {
            var file = e.ClickedItem as File;
            if (file == null)
            {
                return;
            }
            else if (file.FileType == "FOLDER")
            {
                NavigationService.Navigate<FolderPage>(file.Id);
            }
            else if (file.FileType == "VIDEO")
            {
                var url = await Task.Run(() => PutIoService.Get__Files_Url(file.Id));
                if (url?.Url != null)
                {
                    NavigationService.Navigate<PlayerPage>(url.Url);
                }
            }
            else
            {
                // TODO: Show file options dialog
            }
        }
    }
}
