using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using disaster_management.ViewModels.Utils;
using disaster_management.Views.SubWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.ViewModels.ChildViewModels
{
    public partial class DiseaseViewModel
    {
        #region Properties

        private PaginationHelper<Vaccination> _Pagination_Vaccination;
        public PaginationHelper<Vaccination> Pagination_Vaccination
        {
            get => _Pagination_Vaccination;
            set => SetProperty(ref _Pagination_Vaccination, value);
        }


        private ObservableCollection<Vaccination>?  _VaccinationList;
        public ObservableCollection<Vaccination>? VaccinationList
        {
            get { return _VaccinationList; }
            set
            {
                if (_VaccinationList != value)
                {
                    _VaccinationList = value;
                    OnPropertyChanged();
                }
            }
        }

        private Vaccination _vaccination = new();
        public Vaccination Vaccination
        {
            get { return _vaccination; }
            set
            {
                if (_vaccination != value)
                {
                    _vaccination = value;
                    OnPropertyChanged();
                }
            }
        }


        private Vaccination _vaccinationUpdate = new();
        public Vaccination VaccinationUpdate

        {
            get { return _vaccinationUpdate; }
            set
            {
                if (_vaccinationUpdate != value)
                {
                    _vaccinationUpdate = value;
                    OnPropertyChanged();
                }
            }
        }

        private Vaccination _selectedVaccination;
        public Vaccination SelectedVaccination
        {
            get { return _selectedVaccination; }
            set
            {
                SetProperty(ref _selectedVaccination, value);
                if (value != null)
                {
                    VaccinationUpdate = value.Clone();
                    UserOutbreakIDUpdate = (int)VaccinationUpdate.OutbreakId;
                }
            }
        }


        private string _keywordNameVaccination;
        public string KeywordNameVaccination
        {
            get { return _keywordNameVaccination; }
            set
            {
                if (_keywordNameVaccination != value)
                {
                    _keywordNameVaccination = value;
                    OnPropertyChanged();
                }
            }
        }
    


        #endregion

        #region CRUD

        // Load
        public IAsyncRelayCommand LoadVaccinationCommand { get; }
        public async Task GetAllVaccinationAsync()
        {
            if (_vaccinationService == null) return;
           var vaccine =  await _vaccinationService.GetAllAsync();
            VaccinationList = new ObservableCollection<Vaccination>(vaccine);
            Pagination_Vaccination = new PaginationHelper<Vaccination>(VaccinationList,18);
        }

        // Add
        public IAsyncRelayCommand AddVaccinationCommand { get; }
        public async Task AddVaccinationAsync()
        {
            if (_vaccinationService == null) return;
            Vaccination.OutbreakId = UserOutbreakID;
            await _vaccinationService.AddAsync(Vaccination.Clone());
            await GetAllVaccinationAsync();
        }

        // Update
        public IAsyncRelayCommand UpdateVaccinationCommand { get; }
        public async Task UpdateVaccinationAsync()
        {
            if (_vaccinationService == null) return;
            VaccinationUpdate.OutbreakId = UserOutbreakIDUpdate;
            await _vaccinationService.UpdateAsync(VaccinationUpdate.Clone());
            await GetAllVaccinationAsync();
        }

        // Delete
        public IAsyncRelayCommand DeleteVaccinationCommand { get; }
        public async Task DeleteVaccinationAsync()
        {
            try
            {
                if (_vaccinationService == null) return;
                await _vaccinationService.DeleteAsync(SelectedVaccination.VaccinationId);
                await GetAllVaccinationAsync();
            }
            catch (Exception)
            {
            }
           
        }

        // Search
        public IAsyncRelayCommand SearchVaccinationCommand { get; }
        public async Task SearchNameVaccinationAsync()
        {
            if (_vaccinationService == null) return;
            var vaccine = await _vaccinationService.GetByNameSearch(KeywordNameVaccination);
            VaccinationList = new ObservableCollection<Vaccination>(vaccine);
            Pagination_Vaccination = new PaginationHelper<Vaccination>(VaccinationList, 18);
        }

        #endregion
    }
}
