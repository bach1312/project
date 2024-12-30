using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using disaster_management.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.ViewModels.ChildViewModels.Disaster
{
    public partial class DisasterViewModel
    {
        //Pagination
        private PaginationHelper<DisasterPoint> _Pagination_DisasterPoint;
        public PaginationHelper<DisasterPoint> Pagination_DisasterPoint
        {
            get => _Pagination_DisasterPoint;
            set => SetProperty(ref _Pagination_DisasterPoint, value);
        }

        // List
        private ObservableCollection<DisasterPoint> _DisasterPointList;
        public ObservableCollection<DisasterPoint> DisasterPointList
        {
            get { return _DisasterPointList; }
            set
            {
                if (_DisasterPointList != value)
                {
                    _DisasterPointList = value;
                    OnPropertyChanged();
                }
            }
        }
        // DisasterPoint
        private DisasterPoint _disasterPoint = new();
        public DisasterPoint DisasterPoint
        {
            get { return _disasterPoint; }
            set
            {
                if (_disasterPoint != value)
                {
                    _disasterPoint = value;
                    OnPropertyChanged();
                }
            }
        }
        // DisasterPoint Update
        private DisasterPoint _disasterPointUpdate = new();
        public DisasterPoint DisasterPointUpdate
        {
            get { return _disasterPointUpdate; }
            set
            {
                if (_disasterPointUpdate != value)
                {
                    _disasterPointUpdate = value;
                    OnPropertyChanged();
                }
            }
        }
        // Selected DisasterPoint
        private DisasterPoint _selectedDisasterPoint;
        public DisasterPoint SelectedDisasterPoint
        {
            get { return _selectedDisasterPoint; }
            set
            {
                if (_selectedDisasterPoint != value)
                {
                    _selectedDisasterPoint = value;
                   
                    OnPropertyChanged();
                    DisasterPointUpdate = value.Clone();
                }
            }
        }
        // Seach DisasterPoint
        private string _searchDisasterPoint;
        public string SearchDisasterPoint
        {
            get { return _searchDisasterPoint; }
            set
            {
                if (_searchDisasterPoint != value)
                {
                    _searchDisasterPoint = value;
                    OnPropertyChanged();
                }
            }
        }

        // Command
        public IAsyncRelayCommand LoadDisasterPointCommand { get; }
        public IAsyncRelayCommand AddDisasterPointCommand { get; }
        public IAsyncRelayCommand UpdateDisasterPointCommand { get; }
        public IAsyncRelayCommand DeleteDisasterPointCommand { get; }
        public IAsyncRelayCommand SearchDisasterPointCommand { get; }


        // Load DisasterPoint
        private async Task LoadDisasterPointAsync()
        {
            DisasterPointList = new ObservableCollection<DisasterPoint>(
                await disasterPointService.GetAllAsync());
        }

        // Add DisasterPoint
        private async Task AddDisasterPointAsync()
        {
            await disasterPointService.AddAsync(DisasterPoint.Clone());
            await LoadDisasterPointAsync();
        }

        // Update DisasterPoint
        private async Task UpdateDisasterPointAsync()
        {
            await disasterPointService.UpdateAsync(DisasterPointUpdate.Clone());
            await LoadDisasterPointAsync();
        }

        // Delete DisasterPoint
        private async Task DeleteDisasterPointAsync()
        {
            try
            {
                await disasterPointService.DeleteAsync(SelectedDisasterPoint.DisasterId);
                await LoadDisasterPointAsync();
            }
            catch (Exception)
            {
            }
           
        }

        // Search DisasterPoint
        private async Task SearchDisasterPointAsync()
        {
            DisasterPointList = new ObservableCollection<DisasterPoint>(
                await disasterPointService.GetByNameSearch(SearchDisasterPoint));
           // Pagination_DisasterPoint = new PaginationHelper<DisasterPoint>(await disasterPointService.SearchAsync(SearchDisasterPoint));
        }




    }
}
