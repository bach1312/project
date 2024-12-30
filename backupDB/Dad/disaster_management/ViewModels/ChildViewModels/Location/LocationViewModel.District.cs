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

        private ObservableCollection<District> _DistrictList;
        public ObservableCollection<District> DistrictList
        {
            get { return _DistrictList; }
            set
            {
                if (_DistrictList != value)
                {
                    _DistrictList = value;
                    OnPropertyChanged();
                }
            }
        }

        // District Item

        private District _district = new();

        public District District
        {
            get { return _district; }
            set
            {
                if (_district != value)
                {
                    _district = value;
                    OnPropertyChanged();
                }
            }
        }


        private District _DistrictUpdate;

        public District DistrictUpdate
        {
            get { return _DistrictUpdate; }
            set
            {
                if (_DistrictUpdate != value)
                {
                    _DistrictUpdate = value;
                    OnPropertyChanged();
                }
            }
        }

        // Selected district
        private District _selectedDistrict;
        public District SelectedDistrict
        {
            get { return _selectedDistrict; }
            set
            {
                if (_selectedDistrict != value)
                {
                    DistrictUpdate = value.Clone();
                    _selectedDistrict = value;
                    OnPropertyChanged();
                }
            }
        }
        // Search District
        private string _SeachDistrict;
        public string SeachDistrict
        {
            get { return _SeachDistrict; }
            set
            {
                if (_SeachDistrict != value)
                {
                    _SeachDistrict = value;
                    OnPropertyChanged();
                }
            }
        }


        //Command 
        public IAsyncRelayCommand LoadDistrictCommand { get; }
        public IAsyncRelayCommand AddDistrictCommand { get; }
        public IAsyncRelayCommand UpdateDistrictCommand { get; }
        public IAsyncRelayCommand DeleteDistrictCommand { get; }
        public IAsyncRelayCommand SearchDistrictCommand { get; }


        // CRUD 
        private async Task GetAllDistrict()
        {
           DistrictList = new ObservableCollection<District>(
               await districtsService.GetAllAsync());
        }
        private async Task AddDistrictAsync()
        {
            await districtsService.AddAsync(District);
            await GetAllDistrict();
        }
        private async Task UpdateDistrictAsync()
        {
           
            await districtsService.UpdateAsync(DistrictUpdate.Clone());
            await GetAllDistrict();
        }
        private async Task DeleteDistrictAsync()
        {
            try
            {
                await districtsService.DeleteAsync(SelectedDistrict.DistrictId);
                await GetAllDistrict();
            }
            catch (Exception)
            {
            }
         
        }
        private async Task SearchDistrictAsync()
        {
            DistrictList = new ObservableCollection<District>(
                districtsService.GetAllAsync().Result.Where(d => d.DistrictName.ToLower().Contains(_SeachDistrict.ToLower())));
        }
        // open


    }
        
}
