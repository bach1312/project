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
    // Dieu kien trang trai
    public partial class LiveStockViewModel
    {
        #region Properties

        //Pagination
        private PaginationHelper<LivestockFarmCondition> _Pagination_FarmCondition;
        public PaginationHelper<LivestockFarmCondition> Pagination_FarmCondition
        {
            get => _Pagination_FarmCondition;
            set => SetProperty(ref _Pagination_FarmCondition, value);
        }
        // List of Veterinary Branches
        private ObservableCollection<LivestockFarmCondition> _FarmConditionList;
        public ObservableCollection<LivestockFarmCondition> FarmConditionList
        {
            get { return _FarmConditionList; }
            set
            {
                if (_FarmConditionList != value)
                {
                    _FarmConditionList = value;
                    OnPropertyChanged();
                }
            }
        }

        // Veterinary Branch
        private LivestockFarmCondition _FarmCondition = new();
        public LivestockFarmCondition FarmCondition
        {
            get { return _FarmCondition; }
            set
            {
                if (_FarmCondition != value)
                {
                    _FarmCondition = value;
                    OnPropertyChanged();
                }
            }
        }
        // Veterinary Branch Update
        private LivestockFarmCondition _FarmConditionUpdate = new();
        public LivestockFarmCondition FarmConditionUpdate
        {
            get { return _FarmConditionUpdate; }
            set
            {
                if (_FarmConditionUpdate != value)
                {
                    _FarmConditionUpdate = value;
                    OnPropertyChanged();
                }
            }
        }
        // Selected Veterinary Branch
        private LivestockFarmCondition _SelectedFarmCondition;
        public LivestockFarmCondition SelectedFarmCondition
        {
            get { return _SelectedFarmCondition; }
            set
            {
                SetProperty(ref _SelectedFarmCondition, value);
                if (value != null)
                {
                    FarmConditionUpdate = value.Clone();
                }
            }
        }

        // Search
        private string _SearchFarmCondition;
        public string SearchFarmCondition
        {
            get { return _SearchFarmCondition; }
            set
            {
                if (_SearchFarmCondition != value)
                {
                    _SearchFarmCondition = value;
                    OnPropertyChanged();
                }
            }
        }



        #endregion

        #region Command
        public IAsyncRelayCommand LoadFarmConditionCommand { get; }
        public IAsyncRelayCommand AddFarmConditionCommand { get; }
        public IAsyncRelayCommand UpdateFarmConditionCommand { get; }
        public IAsyncRelayCommand DeleteFarmConditionCommand { get; }
        public IAsyncRelayCommand SearchFarmConditionCommand { get; }

        #endregion

        #region Function 
        //Read
        private async Task LoadFarmConditionAsync()
        {
            try
            {
                FarmConditionList = new ObservableCollection<LivestockFarmCondition>(await livestockFarmConditionService.GetAllAsync());
                Pagination_FarmCondition = new PaginationHelper<LivestockFarmCondition>(FarmConditionList);
            }
            catch (Exception ex)
            {
               
            }

        }

        //Create
        private async Task AddFarmConditionAsync()
        {
            try
            {
                await livestockFarmConditionService.AddAsync(FarmCondition.Clone());
                await LoadFarmConditionAsync();
            }
            catch (Exception ex)
            {

            }
        }
        // Update 
        private async Task UpdateFarmConditionAsync()
        {
            try
            {
                await livestockFarmConditionService.UpdateAsync(FarmConditionUpdate.Clone());
                await LoadFarmConditionAsync();
            }
            catch (Exception ex)
            {

            }
        }
        // Delete
        private async Task DeleteFarmConditionAsync()
        {
            try
            {
                await livestockFarmConditionService.DeleteAsync(SelectedFarmCondition.ConditionId);
                await LoadFarmConditionAsync();
            }
            catch (Exception ex)
            {

            }
        }

        private async Task SearchFarmConditionAsync()
        {
           FarmConditionList = new ObservableCollection<LivestockFarmCondition>(
               await livestockFarmConditionService.GetByNameSearch(SearchFarmCondition));
        }
        #endregion
    }
}
