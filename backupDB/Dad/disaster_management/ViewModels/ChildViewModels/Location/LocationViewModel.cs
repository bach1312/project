using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using disaster_management.Services;
using disaster_management.Views.SubWindows;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.ViewModels.ChildViewModels.Location
{
    public partial class LocationViewModel: ObservableObject
    {
        private readonly IDistrictsService districtsService;
        private readonly IProvincesService provincesService;
        private readonly IWardsService wardsService;
        public LocationViewModel(IDistrictsService districtsService,
            IProvincesService provincesService,
            IWardsService wardsService
            ) 
        {
            this.districtsService = districtsService;
            this.provincesService = provincesService;
            this.wardsService = wardsService;

            // Command

            LoadDistrictCommand = new AsyncRelayCommand(GetAllDistrict);
            AddDistrictCommand = new AsyncRelayCommand(AddDistrictAsync);
            UpdateDistrictCommand = new AsyncRelayCommand(UpdateDistrictAsync);
            DeleteDistrictCommand = new AsyncRelayCommand(DeleteDistrictAsync);
            SearchDistrictCommand = new AsyncRelayCommand(SearchDistrictAsync);

            LoadProvinceCommand = new AsyncRelayCommand(GetAllProvince);
            AddProvinceCommand = new AsyncRelayCommand(AddProvinceAsync);
            UpdateProvinceCommand = new AsyncRelayCommand(UpdateProvinceAsync);
            DeleteProvinceCommand = new AsyncRelayCommand(DeleteProvinceAsync);
            SearchProvinceCommand = new AsyncRelayCommand(SearchProvinceAsync);

            LoadWardCommand = new AsyncRelayCommand(GetAllWard);
            AddWardCommand = new AsyncRelayCommand(AddWardAsync);
            DeleteWardCommand = new AsyncRelayCommand(DeleteWardAsync);
            UpdateWardCommand = new AsyncRelayCommand(UpdateWardAsync);
            SearchWardCommand = new AsyncRelayCommand(SearchWardAsync);

            // Popup
            OpenProviceWindowCommand = new RelayCommand(OpenPopupSelectProvinceID);
            OpenDistrictWindowCommand = new RelayCommand(OpenPopupSelectDistrictID);

            LoadDataList();

        }

        private async void LoadDataList()
        {
            await LoadDistrictCommand.ExecuteAsync(null);
            await LoadProvinceCommand.ExecuteAsync(null);
            await LoadWardCommand.ExecuteAsync(null);
        }



        public IRelayCommand OpenProviceWindowCommand { get; }
        public IRelayCommand OpenDistrictWindowCommand { get; }

        private void OpenPopupSelectProvinceID()
        {
            var popupWindow = new SelectProvince
            {
                DataContext = this
            };
            popupWindow.ShowDialog();
        }

        private void OpenPopupSelectDistrictID()
        {
            var popupWindow = new SelectDistrict
            {
                DataContext = this
            };
            popupWindow.ShowDialog();
        }


        private District _districtItem;

        public District DistrictItem
        {
            get { return _districtItem; }
            set
            {
                if (_districtItem != value)
                {
                    _districtItem = value;
                    OnPropertyChanged();

                    Ward.DistrictId = value.DistrictId;
                    OnPropertyChanged(nameof(Ward));

                    WardUpdate.DistrictId = value.DistrictId;
                    OnPropertyChanged(nameof(WardUpdate));


                }
            }
        }



        private Province _ProvinceItem;

        public Province ProvinceItem
        {
            get { return _ProvinceItem; }
            set
            {
                if (_ProvinceItem != value)
                {
                    _ProvinceItem = value;
                    OnPropertyChanged();

                    District.ProvinceId = value.ProvinceId;
                    OnPropertyChanged(nameof(District));

                    DistrictUpdate.ProvinceId = value.ProvinceId;
                    OnPropertyChanged(nameof(DistrictUpdate));
                }
            }
        }
    }
}
