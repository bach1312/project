using CommunityToolkit.Mvvm.ComponentModel;
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

        private PaginationHelper<OutbreakDiagnosis> _Pagination_OD;
        public PaginationHelper<OutbreakDiagnosis> Pagination_OD
        {
            get { return _Pagination_OD; }
            set
            {
                if (_Pagination_OD != value)
                {
                    _Pagination_OD = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<OutbreakDiagnosis>? _od;
        public ObservableCollection<OutbreakDiagnosis>? OD
        {
            get => _od;
            set => SetProperty(ref _od, value);
        }

        private OutbreakDiagnosis _outbreakDia = new();
        public OutbreakDiagnosis OutbreakDia
        {
            get => _outbreakDia;
            set => SetProperty(ref _outbreakDia, value);
        }


        private OutbreakDiagnosis _outbreakDiaUpdate = new();
        public OutbreakDiagnosis OutbreakDiaUpdate
        {
            get => _outbreakDiaUpdate;
            set => SetProperty(ref _outbreakDiaUpdate, value);
        }

        private OutbreakDiagnosis _SelectedOutbreakDia;
        public OutbreakDiagnosis SelectedOutbreakDia
        {
            get { return _SelectedOutbreakDia; }
            set
            {
                SetProperty(ref _SelectedOutbreakDia, value);
                if (value != null)
                {
                    OutbreakDiaUpdate = value.Clone(); // Create a copy
                    UserOutbreakIDUpdate = (int)OutbreakDiaUpdate.OutbreakId;
                }
            }
        }


        private Outbreak _outbreakItem;

        public Outbreak OutbreakItem
        {
            get { return _outbreakItem; }
            set
            {
                if (_outbreakItem != value)
                {
                    _outbreakItem = value;
                    OnPropertyChanged();
                    UserOutbreakID = value.OutbreakId;
                    OutbreakDia.OutbreakId = value.OutbreakId;
                    UserOutbreakIDUpdate = value.OutbreakId;
                  
                }
            }
        }

        private int _UserOutbreakID;
        public int UserOutbreakID
        {
            get { return _UserOutbreakID; }
            set
            {
                if (_UserOutbreakID != value)
                {
                    _UserOutbreakID = value;
                    OnPropertyChanged();
                    OutbreakDiaUpdate.OutbreakId = value;
                 
                }
            }
        }


        private int _UserOutbreakIDUpdate;
        public int UserOutbreakIDUpdate
        {
            get { return _UserOutbreakIDUpdate; }
            set
            {
                if (_UserOutbreakIDUpdate != value)
                {
                    _UserOutbreakIDUpdate = value;
                    OnPropertyChanged();
                    OutbreakDiaUpdate.OutbreakId = value;

                }
            }
        }


        private string _KeywordOutbreakDiaName;

        public string KeywordOutbreakDiaName
        {
            get { return _KeywordOutbreakDiaName; }
            set
            {
                if (_KeywordOutbreakDiaName != value)
                {
                    _KeywordOutbreakDiaName = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region CRUD

        #endregion CRUD

        // READ
        public IAsyncRelayCommand LoadODCommand { get; }
        private async Task GetAllOutBreakDiaAsync()
        {
            if (_outbreakDiagnosisService is null)
            {
                return;
            }
            var ods = await _outbreakDiagnosisService.GetAllAsync();
            OD = new ObservableCollection<OutbreakDiagnosis>(ods);
            Pagination_OD = new PaginationHelper<OutbreakDiagnosis>(OD, 18);
        }

        // ADD
        public IAsyncRelayCommand AddOutbreakDiaCommand { get; }
        private async Task AddOutBreakDiaAsync()
        {
            if (_outbreakDiagnosisService == null) return;
            await _outbreakDiagnosisService.AddAsync(OutbreakDia.Clone());
            await GetAllOutBreakDiaAsync(); // Reload
        }

        // DELETE
        public IAsyncRelayCommand DeleteOutbreakDiaCommand { get; }
        private async Task DeleteOutbreakDiaAsync()
        {
            try
            {
                if (_outbreakDiagnosisService == null) return;
                await _outbreakDiagnosisService.DeleteAsync(SelectedOutbreakDia.DiagnosisId);
                await GetAllOutBreakDiaAsync(); // Reload
            }
            catch (Exception)
            {

               
            }
          
        }

        // UPDATE
        public IAsyncRelayCommand UpdateOutbreakDiaCommand { get; }
        private async Task UpdateOutbreakDiaAsync()
        {
            if (_outbreakDiagnosisService == null) return;
            await _outbreakDiagnosisService.UpdateAsync(OutbreakDiaUpdate);
            await GetAllOutBreakDiaAsync(); // Reload
        }

        // SEARCH
        public IAsyncRelayCommand SearchOutbreakDiaCommand { get; }
        private async Task SearchNameOutbreakDiaAsync()
        {
            if (_outbreakDiagnosisService == null) return;
            var data = await _outbreakDiagnosisService.GetByResultSearch(KeywordOutbreakDiaName);
            OD = new ObservableCollection<OutbreakDiagnosis>(data);
            Pagination_OD = new PaginationHelper<OutbreakDiagnosis>(OD, 18);
        }


        public IRelayCommand SelectOutbreakIDCommand { get; set; }

        private void OpenPopupSelectOutbreakID()
        {
            var popupWindow = new SelectOutbreak
            {
                DataContext = this 
            };
            popupWindow.ShowDialog();
        }


    }
}
