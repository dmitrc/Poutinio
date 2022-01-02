using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Poutinio.Core.Models;
using Poutinio.Core.Services;

namespace Poutinio.Core.ViewModels
{
    public class TransfersViewModel : ObservableObject
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

        private IList<Transfer> _transfers;
        public IList<Transfer> Transfers
        {
            get => _transfers;
            set => SetProperty(ref _transfers, value);
        }

        private ICommand _loadedCommand;
        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new AsyncRelayCommand(OnLoaded));

        private ICommand _transferClickCommand;
        public ICommand TransferClickCommand => _transferClickCommand ?? (_transferClickCommand = new AsyncRelayCommand<Transfer>(OnTransferClick));

        public TransfersViewModel(IPutIoService putIoService, INavigationService navigationService)
        {
            _putIoService = putIoService;
            _navigationService = navigationService;
        }

        private async Task OnLoaded()
        {
            IsLoading = true;
            IsEmpty = false;
            Transfers = null;

            Transfers = await GetTransfers();
            IsLoading = false;
            IsEmpty = (Transfers?.Count ?? 0) == 0;
        }

        private async Task<IList<Transfer>> GetTransfers()
        {
            try
            {
                var transfers = await Task.Run(() => _putIoService.Get__Transfers_List());
                return transfers?.Transfers;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task OnTransferClick(Transfer transfer)
        {
            await Task.CompletedTask;
        }
    }
}
