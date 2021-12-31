using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Poutinio.Core.Models;
using Poutinio.Core.Services;

using File = Poutinio.Core.Models.File;

namespace Poutinio.Core.ViewModels
{
    public class ExplorerViewModel : ObservableObject
    {
        private readonly IPutIoService _putIoService;
        private readonly INavigationService _navigationService;

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        private bool _isEmpty;
        public bool IsEmpty
        {
            get => _isEmpty;
            set => SetProperty(ref _isEmpty, value);
        }

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
        public ICommand FileClickCommand => _fileClickCommand ?? (_fileClickCommand = new AsyncRelayCommand<File>(OnFileClick));

        private ICommand _pathClickCommand;
        public ICommand PathClickCommand => _pathClickCommand ?? (_pathClickCommand = new AsyncRelayCommand<PathItem>(OnPathClick));

        public ExplorerViewModel(IPutIoService putIoService, INavigationService navigationService)
        {
            _putIoService = putIoService;
            _navigationService = navigationService;
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
            IsEmpty = false;
            IsLoading = true;

            var files = await GetFiles(pathItem);

            pathItem.CachedFiles = files;
            Files = files;
            IsEmpty = (files?.Count ?? 0) == 0;
            IsLoading = false;
        }

        private async Task<bool> GoBack()
        {
            var count = Path?.Count ?? 0;
            if (count > 1)
            {
                var previousItem = Path[count - 1];
                Path.RemoveAt(count - 1);

                Files = null;
                IsEmpty = false;
                IsLoading = true;

                var files = await GetFiles(previousItem);

                Files = files;
                IsEmpty = (files?.Count ?? 0) == 0;
                IsLoading = false;

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
                IsEmpty = false;
                IsLoading = true;

                var files = await GetFiles(pathItem);

                Files = files;
                IsLoading = false;
                IsEmpty = (files?.Count ?? 0) == 0;

                return true;
            }
            return false;
        }

        private async Task<IList<File>> GetFiles(PathItem pathItem)
        {
            if (pathItem == null) return null;

            if (pathItem.CachedFiles != null)
            {
                return pathItem.CachedFiles;
            }

            var files = await Task.Run(() => _putIoService.Get__Files_List(pathItem.Id));

            return files?.Files;
        }

        private async Task OnPathClick(PathItem pathItem)
        {
            if (pathItem == null) return;
            await GoBack(pathItem);
        }

        private async Task OnFileClick(File file)
        {
            if (file == null) return;

            if (file.FileType == "FOLDER")
            {
                await OpenFolder(file.Name, file.Id);
            }
            else if (file.FileType == "VIDEO")
            {
                var url = await Task.Run(() => _putIoService.Get__Files_Url(file.Id));
                if (url?.Url != null)
                {
                    _navigationService.Navigate(NavigationKind.Player, url.Url);
                }
            }
            else
            {
                // TODO: Show file options dialog
            }
        }
    }
}
