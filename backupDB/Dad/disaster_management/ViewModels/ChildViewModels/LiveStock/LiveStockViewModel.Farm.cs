using CommunityToolkit.Mvvm.ComponentModel;
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
    /// <summary>
    /// LIVESTOCK FARM
    /// </summary>
    public partial class LiveStockViewModel 
    {
        #region Properties

        // Pagination 
        private PaginationHelper<LivestockFarm> _Pagination_Farm;
        public PaginationHelper<LivestockFarm> Pagination_Farm
        {
            get => _Pagination_Farm;
            set => SetProperty(ref _Pagination_Farm, value);
        }

        // List of Farms
        private ObservableCollection<LivestockFarm> _FarmList;
        public ObservableCollection<LivestockFarm> FarmList
        {
            get { return _FarmList; }
            set
            {
                if (_FarmList != value)
                {
                    _FarmList = value;
                    OnPropertyChanged();
                }
            }
        }

        // Farm
        private LivestockFarm _farm = new();
        public LivestockFarm Farm
        {
            get { return _farm; }
            set
            {
                if (_farm != value)
                {
                    _farm = value;
                    OnPropertyChanged();
                }
            }
        }

        // Farm Update
        private LivestockFarm _farmUpdate = new();
        public LivestockFarm FarmUpdate
        {
            get { return _farmUpdate; }
            set
            {
                if (_farmUpdate != value)
                {
                    _farmUpdate = value;
                    OnPropertyChanged();
                }
            }
        }

        // Selected Farm
        private LivestockFarm _SelectedFarm;
        public LivestockFarm SelectedFarm
        {
            get { return _SelectedFarm; }
            set
            {
                if (_SelectedFarm != value)
                {
                    _SelectedFarm = value;
                    FarmUpdate = value.Clone();
                    OnPropertyChanged();
                }
            }
        }

        private string _searchFarm;

        public string SearchFarm
        {
            get { return _searchFarm; }
            set { _searchFarm = value; OnPropertyChanged(); }
        }


        #endregion

        #region Commands    
        public IAsyncRelayCommand LoadFarmCommand { get; }
        public IAsyncRelayCommand AddFarmCommand { get; }
        public IAsyncRelayCommand UpdateFarmCommand { get; }
        public IAsyncRelayCommand DeleteFarmCommand { get; }
        public IAsyncRelayCommand SearchFarmCommand { get; }
        #endregion

        #region Functions
        private async Task LoadFarmAsync()
        {
            FarmList = new ObservableCollection<LivestockFarm>(await livestockFarmService.GetAllAsync());
            Pagination_Farm = new PaginationHelper<LivestockFarm>(FarmList,18);
        }
        private async Task AddFarmAsync()
        {
            await livestockFarmService.AddAsync(Farm.Clone());
            await LoadFarmAsync();
        }
        private async Task UpdateFarmAsync()
        {
            await livestockFarmService.UpdateAsync(FarmUpdate.Clone());
            await LoadFarmAsync();
        }
        private async Task DeleteFarmAsync()
        {
            await livestockFarmService.DeleteAsync(SelectedFarm.FarmId);
            await LoadFarmAsync();
        }

        private async Task SearchFarmAsync()
        {
           FarmList = new ObservableCollection<LivestockFarm>(
               await livestockFarmService.GetByNameSearch(SearchFarm));
        }
        #endregion
    }
}
