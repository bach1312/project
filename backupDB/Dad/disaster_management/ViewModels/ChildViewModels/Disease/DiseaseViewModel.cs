using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using disaster_management.Services;
using disaster_management.ViewModels.Utils;
using System.Collections.ObjectModel;
using System.Windows;

namespace disaster_management.ViewModels.ChildViewModels
{
    public partial class DiseaseViewModel : ObservableObject
    {
        private readonly IDiseaseTypeService? _diseaseService;
        private readonly IOutbreakDiagnosisService? _outbreakDiagnosisService;
        private readonly IOutbreakService? _outbreakService;
        private readonly ISymptomService? _symptomService;
        private readonly IVaccinationService? _vaccinationService;

        public DiseaseViewModel(
            IDiseaseTypeService diseaseService,
            IOutbreakDiagnosisService? outbreakDiagnosisService,
            IOutbreakService outbreakService,
            ISymptomService symptomService,
            IVaccinationService vaccinationService)
        {
            _diseaseService = diseaseService;
            _outbreakDiagnosisService = outbreakDiagnosisService;
            _outbreakService = outbreakService;
            _symptomService = symptomService;
            _vaccinationService = vaccinationService;

            // Disease
            LoadDiseasesCommand = new AsyncRelayCommand(GetAllDiseasesAsync); // First load
            UpdateDiseaseCommand = new AsyncRelayCommand(UpdateDiseaseAsync);
            AddDiseaseCommand = new AsyncRelayCommand(AddDiseaseAsync);
            DelDiseaseCommand = new AsyncRelayCommand(DeleteDiseaseAsync);
            MoveFirstCommand = new RelayCommand(MoveFirst);
            MovePreviousCommand = new RelayCommand(MovePrevious);
            MoveNextCommand = new RelayCommand(MoveNext);
            MoveLastCommand = new RelayCommand(MoveLast);
            SearchNameCommand = new AsyncRelayCommand(GetBySearchNameAsync);

            // Outbreak command 
            LoadOutBreakCommand = new AsyncRelayCommand(GetAllOutBreakAsync);
            AddOutbreakCommand = new AsyncRelayCommand(AddOutBreakAsync);
            DeleteOutbreakCommand = new AsyncRelayCommand(DeleteOutbreakAsync);
            UpdateOutbreakCommand = new AsyncRelayCommand(UpdateOutbreakAsync);
            SearchOutbreakCommand = new AsyncRelayCommand(SearchNameOutbreakAsync);
            MoveFirstCommand_Outbreak = new RelayCommand(MoveFirst_Outbreak);
            MovePreviousCommand_Outbreak = new RelayCommand(MovePrevious_Outbreak);
            MoveNextCommand_Outbreak = new RelayCommand(MoveNext_Outbreak);
            MoveLastCommand_Outbreak = new RelayCommand(MoveLast_Outbreak);
            OpenPopupSelectDiseaseCommand = new RelayCommand(OpenPopupSelectDisease);

            // Outbreak Diagnosis
            LoadODCommand = new AsyncRelayCommand(GetAllOutBreakDiaAsync);
            SelectOutbreakIDCommand = new RelayCommand(OpenPopupSelectOutbreakID);
            AddOutbreakDiaCommand = new AsyncRelayCommand(AddOutBreakDiaAsync);
            UpdateOutbreakDiaCommand = new AsyncRelayCommand(UpdateOutbreakDiaAsync);
            DeleteOutbreakDiaCommand = new AsyncRelayCommand(DeleteOutbreakDiaAsync);
            SearchOutbreakDiaCommand = new AsyncRelayCommand(SearchNameOutbreakDiaAsync);

            //Symptom
            LoadSymptomCommand = new AsyncRelayCommand(GetAllSymptomAsync);
            AddSymptomCommand = new AsyncRelayCommand(AddSymptomAsync);
            UpdateSymptomCommand = new AsyncRelayCommand(UpdateSymptomAsync);
            DeleteSymptomCommand = new AsyncRelayCommand(DeleteSymptomAsync);
            SearchSymptomCommand = new AsyncRelayCommand(SearchNameSymptomAsync);

            //Vaccination
            LoadVaccinationCommand = new AsyncRelayCommand(GetAllVaccinationAsync);
            AddVaccinationCommand = new AsyncRelayCommand(AddVaccinationAsync);
            UpdateVaccinationCommand = new AsyncRelayCommand(UpdateVaccinationAsync);
            DeleteVaccinationCommand = new AsyncRelayCommand(DeleteVaccinationAsync);
            SearchVaccinationCommand = new AsyncRelayCommand(SearchNameVaccinationAsync);


            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await LoadDiseasesCommand.ExecuteAsync(null);
            await LoadOutBreakCommand.ExecuteAsync(null);
            await LoadODCommand.ExecuteAsync(null);
            await LoadSymptomCommand.ExecuteAsync(null);
            await LoadVaccinationCommand.ExecuteAsync(null);
        }

        #region Prop
        private ObservableCollection<DiseaseType>? _diseases;
        public ObservableCollection<DiseaseType>? Diseases
        {
            get => _diseases;
            set => SetProperty(ref _diseases, value);
        }

        private int _diseaseSeverityIndex;
        public int DiseaseSeverityIndex
        {
            get { return _diseaseSeverityIndex; }
            set
            {
                SetProperty(ref _diseaseSeverityIndex, value);
            }
        }

        private int _diseaseSeverityIndexAdd;
        public int DiseaseSeverityIndexAdd
        {
            get { return _diseaseSeverityIndexAdd; }
            set
            {
                SetProperty(ref _diseaseSeverityIndexAdd, value);
            }
        }

        private int _diseaseGroupIndex;
        public int DiseaseGroupIndex
        {
            get { return _diseaseGroupIndex; }
            set { _diseaseGroupIndex = value; OnPropertyChanged(); }
        }

        private int _diseaseGroupIndexAdd;
        public int DiseaseGroupIndexAdd
        {
            get { return _diseaseGroupIndexAdd; }
            set { _diseaseGroupIndexAdd = value; OnPropertyChanged(); }
        }

        private DiseaseType _SelectedDisease;
        public DiseaseType SelectedDisease
        {
            get { return _SelectedDisease; }
            set
            {
                SetProperty(ref _SelectedDisease, value);
                if (value != null)
                {
                    Disease = value.Clone(); // Create a copy
                    GetSeverityIndex(SelectedDisease);
                    GetGroupIndex(SelectedDisease);
                }

            }
        }

        private DiseaseType _SelectedDiseaseAdd;
        public DiseaseType SelectedDiseaseAdd
        {
            get { return _SelectedDiseaseAdd; }
            set
            {
                SetProperty(ref _SelectedDiseaseAdd, value);
                //  Disease = value.Clone(); // Create a copy

            }
        }

        // Add Data
        private DiseaseType _DiseaseAdd = new();
        public DiseaseType DiseaseAdd
        {
            get { return _DiseaseAdd; }
            set => SetProperty(ref _DiseaseAdd, value);
        }

        // Update Data

        private DiseaseType _Disease = new();
        public DiseaseType Disease
        {
            get { return _Disease; }
            set => SetProperty(ref _Disease, value);
        }


        private string _keywordName = string.Empty;
        public string KeywordName
        {
            get { return _keywordName; }
            set
            {
                if (_keywordName != value)
                {
                    _keywordName = value;
                    OnPropertyChanged();
                }
            }
        }

        private void GetSeverityIndex(DiseaseType diseaseType)
        {
            if (_diseaseService is null)
            {
                return;
            }
            if (diseaseType.Severity == "Nhẹ")
            {
                DiseaseSeverityIndex = 0;
            }
            else if (diseaseType.Severity == "Cảnh báo")
            {
                DiseaseSeverityIndex = 1;
            }
            else if (diseaseType.Severity == "Nguy hiểm")
            {
                DiseaseSeverityIndex = 2;
            }
        }

        private void GetGroupIndex(DiseaseType diseaseType)
        {
            if (_diseaseService is null)
            {
                return;
            }
            if (diseaseType.DiseaseGroup == "Virus")
            {
                DiseaseGroupIndex = 0;
            }
            else if (diseaseType.DiseaseGroup == "Vi Khuẩn")
            {
                DiseaseGroupIndex = 1;
            }
            else if (diseaseType.DiseaseGroup == "Ký Sinh")
            {
                DiseaseGroupIndex = 2;
            }
        }

        private void SetSeverity(int index)
        {
            if (index == 0)
            {
                Disease.Severity = "Nhẹ";
                DiseaseAdd.Severity = "Nhẹ";
            }
            else if (index == 1)
            {
                Disease.Severity = "Cảnh báo";
                DiseaseAdd.Severity = "Cảnh báo";
            }
            else if (index == 2)
            {
                Disease.Severity = "Nguy hiểm";
                DiseaseAdd.Severity = "Nguy hiểm";
            }
        }

        private void SetDiseaseGroup(int index)
        {
            if (index == 0)
            {
                Disease.DiseaseGroup = "Virus";
                DiseaseAdd.DiseaseGroup = "Virus";
            }
            else if (index == 1)
            {
                Disease.DiseaseGroup = "Vi Khuẩn";
                DiseaseAdd.DiseaseGroup = "Vi Khuẩn";
            }
            else if (index == 2)
            {
                Disease.DiseaseGroup = "Ký Sinh";
                DiseaseAdd.DiseaseGroup = "Ký Sinh";
            }
        }

        #region Pagination prop

        private PaginationHelper<DiseaseType> _Pagination;
        public PaginationHelper<DiseaseType> Pagination
        {
            get { return _Pagination; }
            set
            {
                if (_Pagination != value)
                {
                    _Pagination = value;
                    OnPropertyChanged();
                }
            }
        }

        public int CurrentPage => Pagination.CurrentPage;
        public int TotalPages => Pagination.TotalPages;
        #endregion Pagination prop

        #endregion Prop

        #region Pagination
        public IRelayCommand MoveFirstCommand { get; }
        public IRelayCommand MovePreviousCommand { get; }
        public IRelayCommand MoveNextCommand { get; }
        public IRelayCommand MoveLastCommand { get; }
        public void MoveFirst() => Pagination.MoveFirst();
        public void MovePrevious() => Pagination.MovePrevious();
        public void MoveNext() => Pagination.MoveNext();
        public void MoveLast() => Pagination.MoveLast();
        #endregion Pagination

        #region CRUD
        // Download all disease data
        public IAsyncRelayCommand LoadDiseasesCommand { get; }
        private async Task GetAllDiseasesAsync()
        {
            if (_diseaseService is null)
            {
                return;
            }
            var diseases = await _diseaseService.GetAllAsync();
            Diseases = new ObservableCollection<DiseaseType>(diseases);

            // Initialization PaginationHelper
            Pagination = new PaginationHelper<DiseaseType>(Diseases, 18);
        }

        public IAsyncRelayCommand SearchNameCommand { get; }
        public async Task GetBySearchNameAsync()
        {
            if (_diseaseService is null)
            {
                return;
            }
            var diseases = await _diseaseService.GetByNameSearch(KeywordName);
            Diseases = new ObservableCollection<DiseaseType>(diseases);
            Pagination = new PaginationHelper<DiseaseType>(Diseases, 18);

        }

        //Update disease data
        public IAsyncRelayCommand UpdateDiseaseCommand { get; }

        private async Task UpdateDiseaseAsync()
        {

            if (_diseaseService is null)
            {
                return;
            }
            var question = MessageBox.Show("Bạn muốn cập nhật dữ liệu dịch bệnh ?", "Cập Nhật Dữ Liệu", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (question == MessageBoxResult.Cancel) return;
            SetSeverity(DiseaseSeverityIndex);
            SetDiseaseGroup(DiseaseGroupIndex);
            await _diseaseService.UpdateAsync(Disease);
            await GetAllDiseasesAsync();
        }

        //More epidemic data
        public IAsyncRelayCommand AddDiseaseCommand { get; }

        private async Task AddDiseaseAsync()
        {

            if (_diseaseService is null)
            {
                return;
            }
            var question = MessageBox.Show("Bạn muốn thêm dữ liệu dịch bệnh ?", "Thêm Dữ Liệu", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (question == MessageBoxResult.Cancel) return;

            SetSeverity(DiseaseSeverityIndexAdd);
            SetDiseaseGroup(DiseaseGroupIndexAdd);
            await _diseaseService.AddAsync(DiseaseAdd.Clone()); // Clone to keep the value from changing
            await GetAllDiseasesAsync();
        }

        //Delete disease data
        public IAsyncRelayCommand DelDiseaseCommand { get; }

        public async Task DeleteDiseaseAsync()
        {
            try
            {
                if (_diseaseService is null)
                {
                    return;
                }
                var question = MessageBox.Show("Bạn muốn xoá dữ liệu dịch bệnh ?", "Xoá Dữ Liệu", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (question == MessageBoxResult.Cancel) return;
                await _diseaseService.DeleteAsync((Disease.Clone()).DiseaseId);
                await GetAllDiseasesAsync();
            }
            catch (Exception)
            {
            }
          
        }
        #endregion CRUD

    }
}
