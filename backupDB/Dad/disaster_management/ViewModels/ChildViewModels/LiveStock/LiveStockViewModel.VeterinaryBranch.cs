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
    // Chi cuc thu y
    public partial class LiveStockViewModel
    {
        #region Properties

        //Pagination
        private PaginationHelper<VeterinaryBranch> _Pagination_VeterinaryBranch;
        public PaginationHelper<VeterinaryBranch> Pagination_VeterinaryBranch
        {
            get => _Pagination_VeterinaryBranch;
            set => SetProperty(ref _Pagination_VeterinaryBranch, value);
        }
        // List of Veterinary Branches
        private ObservableCollection<VeterinaryBranch> _VeterinaryBranchList;
        public ObservableCollection<VeterinaryBranch> VeterinaryBranchList
        {
            get { return _VeterinaryBranchList; }
            set
            {
                if (_VeterinaryBranchList != value)
                {
                    _VeterinaryBranchList = value;
                    OnPropertyChanged();
                }
            }
        }

        // Veterinary Branch
        private VeterinaryBranch _veterinaryBranch = new();
        public VeterinaryBranch VeterinaryBranch
        {
            get { return _veterinaryBranch; }
            set
            {
                if (_veterinaryBranch != value)
                {
                    _veterinaryBranch = value;
                    OnPropertyChanged();
                }
            }
        }
        // Veterinary Branch Update
        private VeterinaryBranch _veterinaryBranchUpdate = new();
        public VeterinaryBranch VeterinaryBranchUpdate
        {
            get { return _veterinaryBranchUpdate; }
            set
            {
                if (_veterinaryBranchUpdate != value)
                {
                    _veterinaryBranchUpdate = value;
                    OnPropertyChanged();
                }
            }
        }
        // Selected Veterinary Branch
        private VeterinaryBranch _SelectedVeterinaryBranch;
        public VeterinaryBranch SelectedVeterinaryBranch
        {
            get { return _SelectedVeterinaryBranch; }
            set
            {
                SetProperty(ref _SelectedVeterinaryBranch, value);
                if (value != null)
                {
                    VeterinaryBranchUpdate = value.Clone(); // Create a copy
                }
            }
        }

        // Search
        private string _SearchVeterinaryBranch;
        public string SearchVeterinaryBranch
        {
            get { return _SearchVeterinaryBranch; }
            set
            {
                if (_SearchVeterinaryBranch != value)
                {
                    _SearchVeterinaryBranch = value;
                    OnPropertyChanged();
                }
            }
        }



        #endregion

        #region Command
        public IAsyncRelayCommand LoadVeterinaryBranchCommand { get; }
        public IAsyncRelayCommand AddVeterinaryBranchCommand { get; }
        public IAsyncRelayCommand UpdateVeterinaryBranchCommand { get; }
        public IAsyncRelayCommand DeleteVeterinaryBranchCommand { get; }
        public IAsyncRelayCommand SearchVeterinaryBranchCommand { get; }

        #endregion

        private async Task LoadVeterinaryBranchAsync()
        {
            VeterinaryBranchList =
                new ObservableCollection<VeterinaryBranch>(
                    await veterinaryBranchService.GetAllAsync());
            Pagination_VeterinaryBranch = new PaginationHelper<VeterinaryBranch>(VeterinaryBranchList,18);
        }
        // Add Veterinary Branch
        private async Task AddVeterinaryBranchAsync()
        {
            try
            {
                await veterinaryBranchService.AddAsync(VeterinaryBranch.Clone());
                await LoadVeterinaryBranchAsync();
            }
            catch (Exception ex)
            {
              //  await DialogService.ShowMessageAsync(ex.Message);
            }
        }
        // Update Veterinary Branch
        private async Task UpdateVeterinaryBranchAsync()
        {
            try
            {
                await veterinaryBranchService.UpdateAsync(VeterinaryBranchUpdate.Clone());
                await LoadVeterinaryBranchAsync();
            }
            catch (Exception ex)
            {
                //  await DialogService.ShowMessageAsync(ex.Message);
            }
        }
        // Delete Veterinary Branch
        private async Task DeleteVeterinaryBranchAsync()
        {
            try
            {
                await veterinaryBranchService.DeleteAsync(SelectedVeterinaryBranch.BranchId);
                await LoadVeterinaryBranchAsync();
            }
            catch (Exception ex)
            {
                //  await DialogService.ShowMessageAsync(ex.Message);
            }
        }
        private async Task SearchVeterinaryBranchAsync()
        {
           VeterinaryBranchList = new ObservableCollection<VeterinaryBranch>(
               await veterinaryBranchService.GetByNameSearch(SearchVeterinaryBranch));
        }
    }
}
