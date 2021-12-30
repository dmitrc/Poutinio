using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;

// TODO: This is no good
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Yapp.Views;

using Yapp.Models;
using Yapp.Services;

namespace Yapp.ViewModels
{
    public class ExplorerViewModel : ObservableObject
    {
        private readonly IPutIoService PutIoService = Ioc.Default.GetRequiredService<IPutIoService>();

        private IList<File> _files;
        public IList<File> Files
        {
            get => _files;
            set => SetProperty(ref _files, value);
        }

        private ObservableCollection<PathItem> _path;
        public ObservableCollection<PathItem> Path
        {
            get => _path;
            set => SetProperty(ref _path, value);
        }

        private ICommand _loadedCommand;
        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new AsyncRelayCommand(OnLoaded));

        private ICommand _fileClickCommand;
        public ICommand FileClickCommand => _fileClickCommand ?? (_fileClickCommand = new AsyncRelayCommand<ItemClickEventArgs>(OnFileClick));

        private ICommand _pathClickCommand;
        public ICommand PathClickCommand => _pathClickCommand ?? (_pathClickCommand = new AsyncRelayCommand<PathItem>(OnPathClick));

        public ExplorerViewModel()
        {
        }

        private async Task OnLoaded()
        {
            if (Path == null)
            {
                Path = new ObservableCollection<PathItem>();
                await OpenFolder("Home", null);
            }
        }

        private async Task OpenFolder(string name, long? fileId)
        {
            var pathItem = new PathItem()
            {
                Name = name,
                Id = fileId
            };

            Path.Add(pathItem);
            Files = null;

            var files = await GetFiles(pathItem);

            pathItem.CachedFiles = files;
            Files = files;
        }

        private async Task<bool> GoBack()
        {
            var count = Path?.Count ?? 0;
            if (count > 1)
            {
                var previousItem = Path[count - 1];
                Path.RemoveAt(count - 1);

                Files = null;
                var files = await GetFiles(previousItem);
                Files = files;

                return true;
            }
            return false;
        }

        private async Task<bool> GoBack(PathItem pathItem)
        {
            var count = Path?.Count ?? 0;
            var i = Path?.IndexOf(pathItem) ?? -1;
            if (i >= 0 && i != count - 1)
            {
                for (var j = count - 1; j > i; --j)
                {
                    Path.RemoveAt(j);
                }

                Files = null;
                var files = await GetFiles(pathItem);
                Files = files;

                return true;
            }
            return false;
        }

        private async Task<IList<File>> GetFiles(PathItem pathItem)
        {
            if (pathItem.CachedFiles != null)
            {
                return pathItem.CachedFiles;
            }

            var files = await Task.Run(() => PutIoService.Get__Files_List(pathItem.Id));
            return files?.Files;
        }

        private async Task OnPathClick(PathItem pathItem)
        {
            if (pathItem == null) return;
            await GoBack(pathItem);
        }

        private async Task OnFileClick(ItemClickEventArgs e)
        {
            var file = e.ClickedItem as File;
            if (file == null) return;

            if (file.FileType == "FOLDER")
            {
                await OpenFolder(file.Name, file.Id);
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
