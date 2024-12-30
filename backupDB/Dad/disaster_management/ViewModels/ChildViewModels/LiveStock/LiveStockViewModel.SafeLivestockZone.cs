using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using disaster_management.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.ViewModels.ChildViewModels
{
    // vung an toan chan nuoi
    public partial class LiveStockViewModel
    {
        #region Properties

        //Pagination
        private PaginationHelper<SafeLivestockZone> _Pagination_SafeLivestockZone;
        public PaginationHelper<SafeLivestockZone> Pagination_SafeLivestockZone
        {
            get => _Pagination_SafeLivestockZone;
            set => SetProperty(ref _Pagination_SafeLivestockZone, value);
        }

        // List of Veterinary Branches
        private ObservableCollection<SafeLivestockZone> _SafeLivestockZoneList;
        public ObservableCollection<SafeLivestockZone> SafeLivestockZoneList
        {
            get { return _SafeLivestockZoneList; }
            set
            {
                if (_SafeLivestockZoneList != value)
                {
                    _SafeLivestockZoneList = value;
                    OnPropertyChanged();
                }
            }
        }

        // Veterinary Branch
        private SafeLivestockZone _SafeLivestockZone = new();
        public SafeLivestockZone SafeLivestockZone
        {
            get { return _SafeLivestockZone; }
            set
            {
                if (_SafeLivestockZone != value)
                {
                    _SafeLivestockZone = value;
                    OnPropertyChanged();
                }
            }
        }
        // Veterinary Branch Update
        private SafeLivestockZone _SafeLivestockZoneUpdate = new();
        public SafeLivestockZone SafeLivestockZoneUpdate
        {
            get { return _SafeLivestockZoneUpdate; }
            set
            {
                if (_SafeLivestockZoneUpdate != value)
                {
                    _SafeLivestockZoneUpdate = value;
                    OnPropertyChanged();
                }
            }
        }
        // Selected Veterinary Branch
        private SafeLivestockZone _SelectedSafeLivestockZone;
        public SafeLivestockZone SelectedSafeLivestockZone
        {
            get { return _SelectedSafeLivestockZone; }
            set
            {
                SetProperty(ref _SelectedSafeLivestockZone, value);
                if (value != null)

                {
                    SafeLivestockZoneUpdate = value.Clone();
                //    VeterinaryBranchUpdate = value.Clone(); // Create a copy
                }
            }
        }

        // Search
        private string _SearchSafeLivestockZone;
        public string SearchSafeLivestockZone
        {
            get { return _SearchSafeLivestockZone; }
            set
            {
                if (_SearchSafeLivestockZone != value)
                {
                    _SearchSafeLivestockZone = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion
        #region Command
        public IAsyncRelayCommand LoadSafeLivestockZoneCommand { get; }
        public IAsyncRelayCommand AddSafeLivestockZoneCommand { get; }
        public IAsyncRelayCommand UpdateSafeLivestockZoneCommand { get; }
        public IAsyncRelayCommand DeleteSafeLivestockZoneCommand { get; }
        public IAsyncRelayCommand SearchSafeLivestockZoneCommand { get; }

        #endregion

        #region Methods

        private async Task LoadSafeLivestockZoneAsync()
        {
            SafeLivestockZoneList = new ObservableCollection<SafeLivestockZone>(await safeLivestockZoneService.GetAllAsync());
            Pagination_SafeLivestockZone = new PaginationHelper<SafeLivestockZone>(await safeLivestockZoneService.GetAllAsync());
        }

        private async Task AddSafeLivestockZoneAsync()
        {
            try
            {
                await safeLivestockZoneService.AddAsync(SafeLivestockZone);
                await LoadSafeLivestockZoneAsync();
            }
            catch (Exception)
            {
            }
           
        }

        private async Task UpdateSafeLivestockZoneAsync()
        {
            try
            {
                await safeLivestockZoneService.UpdateAsync(SafeLivestockZoneUpdate);
                await LoadSafeLivestockZoneAsync();
            }
            catch (Exception)
            {
            }
        
        }

        private async Task DeleteSafeLivestockZoneAsync()
        {
            try
            {
                await safeLivestockZoneService.DeleteAsync(SelectedSafeLivestockZone.ZoneId);
                await LoadSafeLivestockZoneAsync();
            }
            catch (Exception)
            {
            }
        }

        private async Task SearchSafeLivestockZoneAsync()
        {
           SafeLivestockZoneList = new ObservableCollection<SafeLivestockZone>(
               await safeLivestockZoneService.GetByNameSearch(SearchSafeLivestockZone));
        }

        #endregion

    }
}
