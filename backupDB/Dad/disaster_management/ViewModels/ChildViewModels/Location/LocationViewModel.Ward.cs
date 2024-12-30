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

        private ObservableCollection<Ward> _wardList;
        public ObservableCollection<Ward> WardList
        {
            get { return _wardList; }
            set
            {
                if (_wardList != value)
                {
                    _wardList = value;
                    OnPropertyChanged();
                }
            }
        }



        private Ward _ward;

        public Ward Ward
        {
            get { return _ward; }
            set
            {
                if (_ward != value)
                {
                    _ward = value;
                    OnPropertyChanged();
                }
            }
        }


        private Ward _wardUpdate;

        public Ward WardUpdate
        {
            get { return _wardUpdate; }
            set
            {
                if (_wardUpdate != value)
                {
                    _wardUpdate = value;
                    OnPropertyChanged();
                }
            }
        }


        private Ward _selectedWard;

        public Ward SelectedWard
        {
            get { return _selectedWard; }
            set
            {
                if (_selectedWard != value)
                {
                    _selectedWard = value;
                    WardUpdate = value.Clone();
                    OnPropertyChanged();
                }
            }
        }


        private string _searchWard;
        public string SearchWard
        {
            get { return _searchWard; }
            set
            {
                if (_searchWard != value)
                {
                    _searchWard = value;
                    OnPropertyChanged();
                }
            }
        }

        public IAsyncRelayCommand LoadWardCommand { get; }
        public IAsyncRelayCommand AddWardCommand { get; }
        public IAsyncRelayCommand UpdateWardCommand { get; }
        public IAsyncRelayCommand DeleteWardCommand { get; }
        public IAsyncRelayCommand SearchWardCommand { get; }

        // 
        private async Task GetAllWard()
        {
            WardList =  new ObservableCollection<Ward>(await wardsService.GetAllAsync());
        }

        private async Task AddWardAsync()
        {
            await wardsService.AddAsync(Ward);
            await GetAllWard();
        }

        private async Task UpdateWardAsync()
        {
            await wardsService.UpdateAsync(WardUpdate.Clone());
            await GetAllWard();
        }

        private async Task DeleteWardAsync()
        {
            try
            {
                await wardsService.DeleteAsync(SelectedWard.WardId);
                await GetAllWard();
            }
            catch (Exception)
            {

             
            }
           
        }

        // Search 

        private async Task SearchWardAsync()
        {
            await wardsService.GetByNameSearch(SearchWard);
            await GetAllWard();
        }
    }
}
