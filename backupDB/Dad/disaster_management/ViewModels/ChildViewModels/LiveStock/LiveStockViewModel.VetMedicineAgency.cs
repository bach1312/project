using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using disaster_management.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace disaster_management.ViewModels.ChildViewModels
{
    // Đại lý bán thuốc thú y
    public partial class LiveStockViewModel
    {
        #region Properties
        //Pagination
        private PaginationHelper<VetMedicineAgency> _Pagination_VetMedicineAgency;
        public PaginationHelper<VetMedicineAgency> Pagination_VetMedicineAgency
        {
            get => _Pagination_VetMedicineAgency;
            set => SetProperty(ref _Pagination_VetMedicineAgency, value);
        }
        // List 
        private ObservableCollection<VetMedicineAgency> _VetMedicineAgencyList;
        public ObservableCollection<VetMedicineAgency> VetMedicineAgencyList
        {
            get { return _VetMedicineAgencyList; }
            set
            {
                if (_VetMedicineAgencyList != value)
                {
                    _VetMedicineAgencyList = value;
                    OnPropertyChanged();
                }
            }
        }
        // Veterinary Branch
        private VetMedicineAgency _vetMedicineAgency = new();
        public VetMedicineAgency VetMedicineAgency
        {
            get { return _vetMedicineAgency; }
            set
            {
                if (_vetMedicineAgency != value)
                {
                    _vetMedicineAgency = value;
                    OnPropertyChanged();
                }
            }
        }
        // Veterinary Branch Update
        private VetMedicineAgency _vetMedicineAgencyUpdate = new();
        public VetMedicineAgency VetMedicineAgencyUpdate
        {
            get { return _vetMedicineAgencyUpdate; }
            set
            {
                if (_vetMedicineAgencyUpdate != value)
                {
                    _vetMedicineAgencyUpdate = value;
                    OnPropertyChanged();
                }
            }
        }
        // Selected Veterinary Branch
        private VetMedicineAgency _SelectedVetMedicineAgency;
        public VetMedicineAgency SelectedVetMedicineAgency
        {
            get { return _SelectedVetMedicineAgency; }
            set
            {
                SetProperty(ref _SelectedVetMedicineAgency, value);
                if (value != null)
                {
                    VetMedicineAgencyUpdate = value.Clone(); // Create a copy
                   // UserVetMedicineAgencyIDUpdate = (int)VetMedicineAgencyUpdate.VetMedicineAgencyId;
                }
            }
        }
        // Search
        private string _SearchVetMedicineAgency;
        public string SearchVetMedicineAgency
        {
            get { return _SearchVetMedicineAgency; }
            set
            {
                if (_SearchVetMedicineAgency != value)
                {
                    _SearchVetMedicineAgency = value;
                    OnPropertyChanged();
                }
            }
        }



        #endregion
        #region Command
        public IAsyncRelayCommand LoadVetMedicineAgencyCommand { get; }
        public IAsyncRelayCommand AddVetMedicineAgencyCommand { get; }
        public IAsyncRelayCommand UpdateVetMedicineAgencyCommand { get; }
        public IAsyncRelayCommand DeleteVetMedicineAgencyCommand { get; }
        public IAsyncRelayCommand SearchVetMedicineAgencyCommand { get; }

        #endregion

        #region Methods

        // Read
        private async Task LoadVetMedicineAgencyAsync()
        {
            VetMedicineAgencyList = new ObservableCollection<VetMedicineAgency>(await vetMedicineAgencyService.GetAllAsync());
            Pagination_VetMedicineAgency = new PaginationHelper<VetMedicineAgency>(VetMedicineAgencyList,18);
        }

        //Add VetMedicineAgency
        private async Task AddVetMedicineAgencyAsync()
        {
            await vetMedicineAgencyService.AddAsync(VetMedicineAgency.Clone());
            await LoadVetMedicineAgencyAsync();
        }

        // Update VetMedicineAgency
        private async Task UpdateVetMedicineAgencyAsync()
        {
            await vetMedicineAgencyService.UpdateAsync(VetMedicineAgencyUpdate.Clone());
            await LoadVetMedicineAgencyAsync();
        }

        // Delete VetMedicineAgency
        private async Task DeleteVetMedicineAgencyAsync()
        {
            try
            {
                await vetMedicineAgencyService.DeleteAsync(SelectedVetMedicineAgency.AgencyId);
                await LoadVetMedicineAgencyAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa đại lý bán thuoc thú y này");
            }
           
        }
        private async Task SearchVetMedicineAgencyAsync()
        {
           VetMedicineAgencyList = new ObservableCollection<VetMedicineAgency>(
               await vetMedicineAgencyService.GetByNameSearch(SearchVetMedicineAgency));
        }

        #endregion
    }
}
