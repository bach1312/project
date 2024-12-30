using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.ViewModels.ChildViewModels.Location
{
    public partial class LocationViewModel
    {

        private ObservableCollection<Province> _provinceList;

        public ObservableCollection<Province> ProvinceList
        {
            get { return _provinceList; }
            set
            {
                if (_provinceList != value)
                {
                    _provinceList = value;
                    OnPropertyChanged();
                }
            }
        }

        private Province _province = new();
        public Province Province
        {
            get { return _province; }
            set
            {
                if (_province != value)
                {
                    _province = value;
                    OnPropertyChanged();
                }
            }
        }

        private Province _Selectedrovince;
        public Province SelectedProvince
        {
            get { return _Selectedrovince; }
            set
            {
                if (_Selectedrovince != value)
                {
                    _Selectedrovince = value;
                    ProvinceUpdate = value.Clone();
                    OnPropertyChanged();
                }
            }
        }

        private Province _provinceUpdate;
        public Province ProvinceUpdate
        {
            get { return _provinceUpdate; }
            set
            {
                if (_provinceUpdate != value)
                {
                    _provinceUpdate = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _searchProvince;

        public string SearchProvince
        {
            get { return _searchProvince; }
            set
            {
                if (_searchProvince != value)
                {
                    _searchProvince = value;
                    OnPropertyChanged();
                }
            }
        }


        //Command 
        public IAsyncRelayCommand LoadProvinceCommand { get; }
        public IAsyncRelayCommand AddProvinceCommand { get; }
        public IAsyncRelayCommand UpdateProvinceCommand { get; }
        public IAsyncRelayCommand DeleteProvinceCommand { get; }
        public IAsyncRelayCommand SearchProvinceCommand { get; }


        // CRUD 
        private async Task GetAllProvince()
        {
            ProvinceList = new ObservableCollection<Province>(
                await provincesService.GetAllAsync());
        }
        private async Task AddProvinceAsync()
        {
            await provincesService.AddAsync(Province);
            await GetAllProvince();
        }
        private async Task UpdateProvinceAsync()
        {
            await provincesService.UpdateAsync(ProvinceUpdate.Clone());
            await GetAllProvince();
        }
        private async Task DeleteProvinceAsync()
        {
            try
            {
                await provincesService.DeleteAsync(SelectedProvince.ProvinceId);
                await GetAllProvince();
            }
            catch (Exception)
            {

              
            }
        }
        private async Task SearchProvinceAsync()
        {
            ProvinceList = new ObservableCollection<Province>(
                await provincesService.GetByNameSearch(SearchProvince));
        }


    }
}
