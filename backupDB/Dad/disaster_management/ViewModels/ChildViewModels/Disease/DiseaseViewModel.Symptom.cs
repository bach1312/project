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
    public partial class DiseaseViewModel
    {

        #region Properties

        private PaginationHelper<Symptom> _Pagination_Symptom;
        public PaginationHelper<Symptom> Pagination_Symptom
        {
            get => _Pagination_Symptom;
            set => SetProperty(ref _Pagination_Symptom, value);
        }


        private ObservableCollection<Symptom> _symptomList;
        public ObservableCollection<Symptom> SymptomList
        {
            get { return _symptomList; }
            set
            {
                if (_symptomList != value)
                {
                    _symptomList = value;
                    OnPropertyChanged();
                }
            }
        }


        private Symptom _symptom = new();

        public Symptom Symptom
        {
            get { return _symptom; }
            set
            {
                if (_symptom != value)
                {
                    _symptom = value;
                    OnPropertyChanged();
                }
            }
        }

        private Symptom _symptomUpdate=new();
        public Symptom SymptomUpdate
        {
            get { return _symptomUpdate; }
            set
            {
                if (_symptomUpdate != value)
                {
                    _symptomUpdate = value;
                    OnPropertyChanged();
                }
            }
        }

        private Symptom _selectedSymptom;
        public Symptom SelectedSymptom
        {
            get { return _selectedSymptom; }
            set
            {
                if (_selectedSymptom != value)
                {
                    _selectedSymptom = value;
                    OnPropertyChanged();
                    if (value != null)
                    {
                        SymptomUpdate = value.Clone();
                    }
                }
            }
        }


        private string _keyworkSymptomName;
        public string KeyworkSymptomName
        {
            get { return _keyworkSymptomName; }
            set
            {
                if (_keyworkSymptomName != value)
                {
                    _keyworkSymptomName = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region CRUD

        // LOAD
        public IAsyncRelayCommand LoadSymptomCommand { get;}
        public async Task GetAllSymptomAsync()
        {
            try
            {
                if (_symptomService == null) return;
                var data = await _symptomService.GetAllAsync();
                SymptomList = new ObservableCollection<Symptom>(data);
                Pagination_Symptom = new PaginationHelper<Symptom>(SymptomList,18);
            }
            catch (Exception ex)
            {

            }
        }
        // ADD

        public IAsyncRelayCommand AddSymptomCommand { get; }
        public async Task AddSymptomAsync()
        {
            try
            {
                if (_symptomService == null) return;
                await _symptomService.AddAsync(Symptom.Clone());
                await GetAllSymptomAsync();    
            }
            catch (Exception)
            {
            }
        }

        // UPDATE
        public IAsyncRelayCommand UpdateSymptomCommand { get; }
        public async Task UpdateSymptomAsync()
        {
            try
            {
                if (_symptomService == null) return;
                await _symptomService.UpdateAsync(SymptomUpdate);
                await GetAllSymptomAsync();
            }
            catch (Exception)
            {
            }
        }

        // DELETE
        public IAsyncRelayCommand DeleteSymptomCommand { get; }
        public async Task DeleteSymptomAsync()
        {
            try
            {
                if (_symptomService == null) return;
                await _symptomService.DeleteAsync(SelectedSymptom.SymptomId);
                await GetAllSymptomAsync();
            }
            catch (Exception)
            {
            }
        }

        // SEARCH   
        public IAsyncRelayCommand SearchSymptomCommand { get; }
        public async Task SearchNameSymptomAsync()
        {
            try
            {
                if (_symptomService == null) return;
                var data = await _symptomService.GetByNameSearch(KeyworkSymptomName);
                SymptomList = new ObservableCollection<Symptom>(data);
                Pagination_Symptom = new PaginationHelper<Symptom>(SymptomList, 18);
            }
            catch (Exception)
            {
            }
        }

        #endregion
    }
}
