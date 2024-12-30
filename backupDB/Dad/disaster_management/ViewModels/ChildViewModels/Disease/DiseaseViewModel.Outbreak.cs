using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using disaster_management.ViewModels.Utils;
using disaster_management.Views.SubWindows;
using System.Collections.ObjectModel;

namespace disaster_management.ViewModels.ChildViewModels
{
    public partial class DiseaseViewModel
    {
        #region Properties
       
        private PaginationHelper<Outbreak> _Pagination_Outbreak;
        public PaginationHelper<Outbreak> Pagination_Outbreak
        {
            get => _Pagination_Outbreak;
            set => SetProperty(ref _Pagination_Outbreak, value);
        }

        private ObservableCollection<Outbreak>? _outBreakList;
        public ObservableCollection<Outbreak>? OutBreakList
        {
            get => _outBreakList;
            set => SetProperty(ref _outBreakList, value);
        }

        // Add
        private Outbreak _outbreak = new();
        public Outbreak Outbreak
        {
            get => _outbreak;
            set => SetProperty(ref _outbreak, value);
        }

        // Update
        private Outbreak _outbreakUpdate = new();
        public Outbreak OutbreakUpdate
        {
            get => _outbreakUpdate;
            set => SetProperty(ref _outbreakUpdate, value);
        }

        private Outbreak _selectedOutbreak;
        public Outbreak SelectedOutbreak
        {
            get => _selectedOutbreak;
            set
            {
                SetProperty(ref _selectedOutbreak, value);
                if (value != null)
                {
                    OutbreakUpdate = value.Clone();
                    UserDiseaseIdUpdate = (int)OutbreakUpdate.DiseaseId;
                    ChangeStatusUpdate();
                }
                    
            }
        }

        private DiseaseType _diseaseItem;
        public DiseaseType DiseaseItem
        {
            get { return _diseaseItem; }
            set
            {
                _diseaseItem = value;
                OnPropertyChanged();
                if (value != null)
                {
                    UserDiseaseId = value.DiseaseId;
                    Outbreak.DiseaseId = value.DiseaseId;

                }
            }
        }

        private int _SelectedIndexOutbreakUpdate;
        public int SelectedIndexOutbreakUpdate
        {
            get { return _SelectedIndexOutbreakUpdate; }
            set { _SelectedIndexOutbreakUpdate = value; OnPropertyChanged(); }
        }

        private int _UserDiseaseId;
        public int UserDiseaseId
        {
            get { return _UserDiseaseId; }
            set
            {
                if (_UserDiseaseId != value)
                {
                    _UserDiseaseId = value; 
                    OnPropertyChanged();
                    OutbreakUpdate.DiseaseId = value;
                    UserDiseaseIdUpdate = value;
                }
            }
        }

        // ID for update
        private int _UserDiseaseIdUpdate;
        public int UserDiseaseIdUpdate
        {
            get { return _UserDiseaseIdUpdate; }
            set { _UserDiseaseIdUpdate = value; OnPropertyChanged(); }
        }

        private int _SelectedIndexStatusOutBreak;
        public int SelectedIndexStatusOutBreak
        {
            get { return _SelectedIndexStatusOutBreak; }
            set
            {
                if (_SelectedIndexStatusOutBreak != value)
                {
                    _SelectedIndexStatusOutBreak = value;
                    OnPropertyChanged();

                }

            }
        }

        private string _KeywordOutbreakName;
        public string KeywordOutbreakName
        {
            get { return _KeywordOutbreakName; }
            set { _KeywordOutbreakName = value; OnPropertyChanged(); }
        }

        #endregion Properties

        #region Pagination
        public IRelayCommand MoveFirstCommand_Outbreak { get; }
        public IRelayCommand MovePreviousCommand_Outbreak { get; }
        public IRelayCommand MoveNextCommand_Outbreak { get; }
        public IRelayCommand MoveLastCommand_Outbreak { get; }
        public void MoveFirst_Outbreak() => Pagination_Outbreak.MoveFirst();
        public void MovePrevious_Outbreak() => Pagination_Outbreak.MovePrevious();
        public void MoveNext_Outbreak() => Pagination_Outbreak.MoveNext();
        public void MoveLast_Outbreak() => Pagination_Outbreak.MoveLast();
        #endregion Pagination

        #region CRUD
        public IAsyncRelayCommand LoadOutBreakCommand { get; }
        private async Task GetAllOutBreakAsync()
        {
            if (_outbreakService is null)
            {
                return;
            }
            var outbreak = await _outbreakService.GetAllAsync();
            OutBreakList = new ObservableCollection<Outbreak>(outbreak);
            Pagination_Outbreak = new PaginationHelper<Outbreak>(OutBreakList, 18);
        }
        // ADD
        public IAsyncRelayCommand AddOutbreakCommand { get; }
        private async Task AddOutBreakAsync()
        {
            if (_SelectedIndexStatusOutBreak == 0)
            {
                Outbreak.Status = "Mới phát hiện";
            }
            else if (SelectedIndexStatusOutBreak == 1)
            {
                Outbreak.Status = "Đang xử lý";
            }
            else if (_SelectedIndexStatusOutBreak == 2)
            {
                Outbreak.Status = "Đã xử lý";
            }
            await _outbreakService.AddAsync(Outbreak.Clone());
            await GetAllOutBreakAsync(); // Reload
        }

        // DELETE
        public IAsyncRelayCommand DeleteOutbreakCommand { get; }
        private async Task DeleteOutbreakAsync()
        {
            try
            {
                if (_outbreakService == null) return;
                await _outbreakService.DeleteAsync(SelectedOutbreak.OutbreakId);
                await GetAllOutBreakAsync(); // Reload
            }
            catch (Exception)
            {
            }
            
        }

        private void ChangeStatusUpdate()
        {
            if (OutbreakUpdate.Status.Equals("Mới phát hiện"))
            {
                SelectedIndexOutbreakUpdate = 0;
            }
            else if (OutbreakUpdate.Status.Equals("Đang xử lý"))
            {
                SelectedIndexOutbreakUpdate = 1;
            }
            else if (OutbreakUpdate.Status.Equals("Đã xử lý"))
            {
                SelectedIndexOutbreakUpdate = 2;
            }
        }

        // UPDATE
        public IAsyncRelayCommand UpdateOutbreakCommand { get; }
        private async Task UpdateOutbreakAsync()
        {
            if (_outbreakService == null) return;

            if (SelectedIndexOutbreakUpdate == 0)
            {
                OutbreakUpdate.Status = "Mới phát hiện";
            }
            else if (SelectedIndexOutbreakUpdate == 1)
            {
                OutbreakUpdate.Status = "Đang xử lý";
            }
            else if (SelectedIndexOutbreakUpdate == 2)
            {
                OutbreakUpdate.Status = "Đã xử lý";
            }
            await _outbreakService.UpdateAsync(OutbreakUpdate);
            await GetAllOutBreakAsync(); // Reload
        }

      
        // SEARCH
        public IAsyncRelayCommand SearchOutbreakCommand { get; }

        private async Task SearchNameOutbreakAsync()
        {
            if (_outbreakService == null) return;
            var data =  await _outbreakService.GetByNameSearch(KeywordOutbreakName);
            OutBreakList = new ObservableCollection<Outbreak>(data);
            Pagination_Outbreak = new PaginationHelper<Outbreak>(OutBreakList,18);
        }

        #endregion CRUD

        public IRelayCommand OpenPopupSelectDiseaseCommand { get; }
        private void OpenPopupSelectDisease()
        {
            var popupWindow = new SelectDisease
            {
                DataContext = this // Sử dụng chung ViewModel
            };
            popupWindow.ShowDialog();
        }
    }
}
