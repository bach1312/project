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
        private PaginationHelper<Report> _Pagination_Report;
        public PaginationHelper<Report> Pagination_Report
        {
            get => _Pagination_Report;
            set => SetProperty(ref _Pagination_Report, value);
        }

        // Report
        private Report _report = new();
        public Report Report
        {
            get { return _report; }
            set
            {
                if (_report != value)
                {
                    _report = value;
                    OnPropertyChanged();
                }
            }
        }
        // Report Update
        private Report _reportUpdate = new();
        public Report ReportUpdate
        {
            get { return _reportUpdate; }
            set
            {
                if (_reportUpdate != value)
                {
                    _reportUpdate = value;
                    OnPropertyChanged();
                }
            }
        }
        // Selected Report
        private Report _selectedReport;
        public Report SelectedReport
        {
            get { return _selectedReport; }
            set
            {
                if (_selectedReport != value)
                {
                    _selectedReport = value;
                    OnPropertyChanged();
                }
            }
        }
        // Report List
        private ObservableCollection<Report> _reportList;
        public ObservableCollection<Report> ReportList
        {
            get { return _reportList; }
            set
            {
                if (_reportList != value)
                {
                    _reportList = value;
                    OnPropertyChanged();
                }
            }
        }
        // Search Report
        private string _searchReport;
        public string SearchReport
        {
            get { return _searchReport; }
            set
            {
                if (_searchReport != value)
                {
                    _searchReport = value;
                    OnPropertyChanged();
                }
            }
        }

        // Commands
        public AsyncRelayCommand LoadReportCommand { get; private set; }
        public AsyncRelayCommand AddReportCommand { get; private set; }
        public AsyncRelayCommand UpdateReportCommand { get; private set; }
        public AsyncRelayCommand DeleteReportCommand { get; private set; }

        // Method

        #region Functions

        //Read
        private async Task LoadReportAsync()
        {
            ReportList = new ObservableCollection<Report>(await reportService.GetAllAsync());
            Pagination_Report = new PaginationHelper<Report>(ReportList, 18);
        }
        //Add
        private async Task AddReportAsync()
        {
            try
            {
                await reportService.AddAsync(Report.Clone());
                await LoadReportAsync();
            }
            catch (Exception)
            {
            }
           
        }
        //Update
        private async Task UpdateReportAsync()
        {
            try
            {
                await reportService.UpdateAsync(ReportUpdate.Clone());
                await LoadReportAsync();
            }
            catch (Exception)
            {
            }
         
        }
        //Delete
        private async Task DeleteReportAsync()
        {
            try
            {
                await reportService.DeleteAsync(SelectedReport.ReportId);
                await LoadReportAsync();
            }
            catch (Exception)
            {
            }
           
        }
        //Search
        private async Task SearchReportAsync()
        {
          //  ReportList = new ObservableCollection<Report>(await reportService.SearchAsync(SearchReport));
         //   Pagination_Report = new PaginationHelper<Report>(ReportList, 18);
        }

        #endregion

    }
}
