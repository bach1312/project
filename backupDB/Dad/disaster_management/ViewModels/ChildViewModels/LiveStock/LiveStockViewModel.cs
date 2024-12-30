using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using disaster_management.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.ViewModels.ChildViewModels
{
    public partial class LiveStockViewModel : ObservableObject
    {
        // Service declaration
        private readonly ICertificateService certiticateService;
        private readonly ILivestockFarmService livestockFarmService;
        private readonly ILivestockFarmConditionService livestockFarmConditionService;
        private readonly ISlaughterhouseService slaughterhouseService;
        private readonly ISafeLivestockZoneService safeLivestockZoneService;
        private readonly ILivestockStatisticService livestockStatisticService;
        private readonly ITemporaryZoneService temporaryZoneService;
        private readonly IVeterinaryBranchService veterinaryBranchService;
        private readonly IVetMedicineAgencyService vetMedicineAgencyService;    

        public LiveStockViewModel(
            ICertificateService certiticateService,
            ILivestockFarmService livestockFarmService,
            ILivestockFarmConditionService livestockFarmConditionService,
            ISlaughterhouseService slaughterhouse,
            ISafeLivestockZoneService safeLivestockZoneService,
            ILivestockStatisticService livestockStatisticService, 
            ITemporaryZoneService temporaryZoneService,
            IVeterinaryBranchService veterinaryBranchService,
            IVetMedicineAgencyService vetMedicineAgencyService)
        {
            this.certiticateService = certiticateService;
            this.livestockFarmService = livestockFarmService;
            this.livestockFarmConditionService = livestockFarmConditionService;
            this.slaughterhouseService = slaughterhouse;
            this.safeLivestockZoneService = safeLivestockZoneService;
            this.livestockStatisticService = livestockStatisticService;
            this.temporaryZoneService = temporaryZoneService;
            this.veterinaryBranchService = veterinaryBranchService;
            this.vetMedicineAgencyService = vetMedicineAgencyService;

            // Command Register
            // Chi cục
            LoadVeterinaryBranchCommand = new AsyncRelayCommand(LoadVeterinaryBranchAsync);
            AddVeterinaryBranchCommand = new AsyncRelayCommand(AddVeterinaryBranchAsync);
            UpdateVeterinaryBranchCommand = new AsyncRelayCommand(UpdateVeterinaryBranchAsync);
            DeleteVeterinaryBranchCommand = new AsyncRelayCommand(DeleteVeterinaryBranchAsync);
            SearchVeterinaryBranchCommand = new AsyncRelayCommand(SearchVeterinaryBranchAsync);

            //Đại lý bán thuốc thú y
            LoadVetMedicineAgencyCommand = new AsyncRelayCommand(LoadVetMedicineAgencyAsync);
            AddVetMedicineAgencyCommand = new AsyncRelayCommand(AddVetMedicineAgencyAsync);
            UpdateVetMedicineAgencyCommand = new AsyncRelayCommand(UpdateVetMedicineAgencyAsync);
            DeleteVetMedicineAgencyCommand = new AsyncRelayCommand(DeleteVetMedicineAgencyAsync);
            SearchVetMedicineAgencyCommand =  new AsyncRelayCommand(SearchVetMedicineAgencyAsync);

            // Temporary Zone
            LoadTemporaryZoneCommand = new AsyncRelayCommand(LoadTemporaryZoneAsync);
            AddTemporaryZoneCommand = new AsyncRelayCommand(AddTemporaryZoneAsync);
            UpdateTemporaryZoneCommand = new AsyncRelayCommand(UpdateTemporaryZoneAsync);
            DeleteTemporaryZoneCommand = new AsyncRelayCommand(DeleteTemporaryZoneAsync);
            SearchTemporaryZoneCommand = new AsyncRelayCommand(SearchTemporaryZoneAsync);

            // Slaughter
            LoadSlaughterhouseCommand = new AsyncRelayCommand(LoadSlaughterhouseAsync);
            AddSlaughterhouseCommand = new AsyncRelayCommand(AddSlaughterhouseAsync);
            UpdateSlaughterhouseCommand = new AsyncRelayCommand(UpdateSlaughterhouseAsync);
            DeleteSlaughterhouseCommand = new AsyncRelayCommand(DeleteSlaughterhouseAsync);
            SearchSlaughterhouseCommand = new AsyncRelayCommand(SearchSlaughterhouseAsync);


            // Farm
            LoadFarmCommand = new AsyncRelayCommand(LoadFarmAsync);
            AddFarmCommand = new AsyncRelayCommand(AddFarmAsync);
            UpdateFarmCommand = new AsyncRelayCommand(UpdateFarmAsync);
            DeleteFarmCommand = new AsyncRelayCommand(DeleteFarmAsync);
            SearchFarmCommand = new AsyncRelayCommand(SearchFarmAsync);

            //Farm condition
            LoadFarmConditionCommand = new AsyncRelayCommand(LoadFarmConditionAsync);
            AddFarmConditionCommand = new AsyncRelayCommand(AddFarmConditionAsync);
            UpdateFarmConditionCommand = new AsyncRelayCommand(UpdateFarmConditionAsync);
            DeleteFarmConditionCommand = new AsyncRelayCommand(DeleteFarmConditionAsync);
            SearchFarmConditionCommand = new AsyncRelayCommand(SearchFarmConditionAsync);

            // Certificate Command
            LoadCertificateCommand = new AsyncRelayCommand(LoadCertificateAsync);
            OpenFarmWindowCommand = new RelayCommand(OpenPopupSelectFarmID);
            AddCertificateCommand = new AsyncRelayCommand(AddCertificateAsync);
            UpdateCertificateCommand = new AsyncRelayCommand(UpdateCertificateAsync);
            DeleteCertificateCommand = new AsyncRelayCommand(DeleteCertificateAsync);
            SearchCertificateCommand = new AsyncRelayCommand(SearchCertificateAsync);

            //Statistic
            LoadStatisticCommand = new AsyncRelayCommand(LoadStatisticAsync);
            AddStatisticCommand = new AsyncRelayCommand(AddStatisticAsync);
            UpdateStatisticCommand = new AsyncRelayCommand(UpdateStatisticAsync);
            DeleteStatisticCommand = new AsyncRelayCommand(DeleteStatisticAsync);
            SearchStatisticCommand = new AsyncRelayCommand(SearchStatisticAsync);

            //Safe Livestock Zone
            LoadSafeLivestockZoneCommand = new AsyncRelayCommand(LoadSafeLivestockZoneAsync);
            AddSafeLivestockZoneCommand = new AsyncRelayCommand(AddSafeLivestockZoneAsync);
            UpdateSafeLivestockZoneCommand = new AsyncRelayCommand(UpdateSafeLivestockZoneAsync);
            DeleteSafeLivestockZoneCommand = new AsyncRelayCommand(DeleteSafeLivestockZoneAsync);
            SearchSafeLivestockZoneCommand = new AsyncRelayCommand(SearchSafeLivestockZoneAsync);

           
            InitializeAsync();
        }
        private async void InitializeAsync()
        {
            await LoadCertificateCommand.ExecuteAsync(null);
            await LoadFarmCommand.ExecuteAsync(null);
            await LoadVeterinaryBranchCommand.ExecuteAsync(null);
            await LoadVetMedicineAgencyCommand.ExecuteAsync(null);
            await LoadTemporaryZoneCommand.ExecuteAsync(null);
            await LoadSlaughterhouseCommand.ExecuteAsync(null);
            await LoadFarmConditionCommand.ExecuteAsync(null);
            await LoadStatisticCommand.ExecuteAsync(null);
            await LoadSafeLivestockZoneCommand.ExecuteAsync(null);
        }


        private LivestockFarm _FarmItem;
        public LivestockFarm FarmItem
        {
            get { return _FarmItem; }
            set { _FarmItem = value; 
                OnPropertyChanged(); 
                Certificate.FarmId = FarmItem.FarmId;
                OnPropertyChanged("Certificate");

                CertificateUpdate.FarmId = FarmItem.FarmId;
                OnPropertyChanged("CertificateUpdate");

                FarmCondition.FarmId = FarmItem.FarmId;
                OnPropertyChanged("FarmCondition");

                FarmConditionUpdate.FarmId = FarmItem.FarmId;
                OnPropertyChanged("FarmConditionUpdate");

                Statistic.FarmId = FarmItem.FarmId;
                OnPropertyChanged("Statistic");

                StatisticUpdate.FarmId = FarmItem.FarmId;
                OnPropertyChanged("StatisticUpdate");
            }
        }

    }
}
