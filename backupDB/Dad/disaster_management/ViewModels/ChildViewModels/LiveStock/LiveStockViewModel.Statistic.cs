using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using disaster_management.ViewModels.Utils;
using System.Collections.ObjectModel;

namespace disaster_management.ViewModels.ChildViewModels
{
    // Thong ke
    public partial class LiveStockViewModel
    {
        //Pagination
        private PaginationHelper<LivestockStatistic> _Pagination_Statistic;
        public PaginationHelper<LivestockStatistic> Pagination_Statistic
        {
            get => _Pagination_Statistic;
            set => SetProperty(ref _Pagination_Statistic, value);
        }
        // List
        private ObservableCollection<LivestockStatistic> _StatisticList;
        public ObservableCollection<LivestockStatistic> StatisticList
        {
            get { return _StatisticList; }
            set
            {
                if (_StatisticList != value)
                {
                    _StatisticList = value;
                    OnPropertyChanged();
                }
            }
        }
        // Statistic
        private LivestockStatistic _statistic = new();
        public LivestockStatistic Statistic
        {
            get { return _statistic; }
            set
            {
                if (_statistic != value)
                {
                    _statistic = value;
                    OnPropertyChanged();
                }
            }
        }
        // Statistic Update
        private LivestockStatistic _statisticUpdate = new();
        public LivestockStatistic StatisticUpdate
        {
            get { return _statisticUpdate; }
            set
            {
                if (_statisticUpdate != value)
                {
                    _statisticUpdate = value;
                    OnPropertyChanged();
                }
            }
        }
        // Selected Statistic
        private LivestockStatistic _selectedStatistic;
        public LivestockStatistic SelectedStatistic
        {
            get { return _selectedStatistic; }
            set
            {
                if (_selectedStatistic != value)
                {
                    _selectedStatistic = value;
                    StatisticUpdate = value.Clone(); // Create a copy   
                    OnPropertyChanged();
                }
            }
        }
        //Search
        private string _searchStatistic;
        public string SearchStatistic
        {
            get { return _searchStatistic; }
            set
            {
                if (_searchStatistic != value)
                {
                    _searchStatistic = value;
                    OnPropertyChanged();
                }
            }
        }

        #region Command
        public IAsyncRelayCommand LoadStatisticCommand { get; }
        public IAsyncRelayCommand AddStatisticCommand { get; }
        public IAsyncRelayCommand UpdateStatisticCommand { get; }
        public IAsyncRelayCommand DeleteStatisticCommand { get; }
        public IAsyncRelayCommand SearchStatisticCommand { get; }

        #endregion

        #region Functions
        //Read
        private async System.Threading.Tasks.Task LoadStatisticAsync()
        {
            try
            {
                StatisticList = new ObservableCollection<LivestockStatistic>(await livestockStatisticService.GetAllAsync());
                Pagination_Statistic = new PaginationHelper<LivestockStatistic>(StatisticList, 18);
            }
            catch (Exception)
            {
            }
          
        }
        //Create
        private async System.Threading.Tasks.Task AddStatisticAsync()
        {
            try
            {
                await livestockStatisticService.AddAsync(Statistic.Clone());
                await LoadStatisticAsync();
            }
            catch (Exception)
            {
            }
           
        }
        // Update
        private async System.Threading.Tasks.Task UpdateStatisticAsync()
        {
            try
            {
                await livestockStatisticService.UpdateAsync(StatisticUpdate);
                await LoadStatisticAsync();
            }
            catch (Exception)
            {
            }
          
        }
        // Delete
        private async System.Threading.Tasks.Task DeleteStatisticAsync()
        {
            try
            {
                await livestockStatisticService.DeleteAsync(SelectedStatistic.StatisticId);
                await LoadStatisticAsync();

            }
            catch (Exception)
            {
            }
      
        }
        private async Task SearchStatisticAsync()
        {
           StatisticList = new ObservableCollection<LivestockStatistic>(
               await livestockStatisticService.GetByNameSearch(SearchStatistic));
        }
        #endregion
    }
}
