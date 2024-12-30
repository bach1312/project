using CommunityToolkit.Mvvm.Input;
using disaster_management.Models;
using disaster_management.ViewModels.Utils;
using disaster_management.Views.SubWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.ViewModels.ChildViewModels
{
    public partial class LiveStockViewModel
    {
        #region Properties

        // Pagination 
        private PaginationHelper<Certificate> _Pagination_Certificate;
        public PaginationHelper<Certificate> Pagination_Certificate
        {
            get => _Pagination_Certificate;
            set => SetProperty(ref _Pagination_Certificate, value);
        }

        // List of Certificates
        private ObservableCollection<Certificate> _CertificateList;
        public ObservableCollection<Certificate> CertificateList
        {
            get { return _CertificateList; }
            set
            {
                if (_CertificateList != value)
                {
                    _CertificateList = value;
                    OnPropertyChanged();
                }
            }
        }

        // Certificate
        private Certificate _certificate = new();
        public Certificate Certificate
        {
            get { return _certificate; }
            set
            {
                if (_certificate != value)
                {
                    _certificate = value;
                    OnPropertyChanged();
                }
            }
        }

        // Certificate Update
        private Certificate _certificateUpdate = new();
        public Certificate CertificateUpdate
        {
            get { return _certificateUpdate; }
            set
            {
                if (_certificateUpdate != value)
                {
                    _certificateUpdate = value;
                    OnPropertyChanged();
                }
            }
        }

        // Selected Certificate
        private Certificate _selectedCertificate;
        public Certificate SelectedCertificate
        {
            get { return _selectedCertificate; }
            set
            {
                if (_selectedCertificate != value && value != null)
                {
                    _selectedCertificate = value;
                    OnPropertyChanged();
                    Certificate.FarmId = value.FarmId;
                    OnPropertyChanged("Certificate");

                    CertificateUpdate = value.Clone();
                    CertificateUpdate.FarmId = value.FarmId;
                    OnPropertyChanged("CertificateUpdate");
                }
            }
        }

        // Certificate Search
        private string _certificateKeyword;
        public string SearchCertificate
        {
            get { return _certificateKeyword; }
            set
            {
                if (_certificateKeyword != value)
                {
                    _certificateKeyword = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion

        #region CRUD

        //Command 
        public IAsyncRelayCommand LoadCertificateCommand { get; }
        public IAsyncRelayCommand AddCertificateCommand { get; }
        public IAsyncRelayCommand UpdateCertificateCommand { get; }
        public IAsyncRelayCommand DeleteCertificateCommand { get; }
        public IAsyncRelayCommand SearchCertificateCommand { get; }

        public IRelayCommand OpenFarmWindowCommand { get; }

        // Function
        //Read
        private async Task LoadCertificateAsync()
        {
            var certificateList = await certiticateService.GetAllAsync();
            CertificateList = new ObservableCollection<Certificate>(certificateList);
            Pagination_Certificate = new PaginationHelper<Certificate>(CertificateList,18);
        }

        //Create
        private async Task AddCertificateAsync()
        {
            await certiticateService.AddAsync(Certificate.Clone());
            await LoadCertificateAsync();
        }
        //Update
        private async Task UpdateCertificateAsync()
        {
            await certiticateService.UpdateAsync(CertificateUpdate.Clone());
            await LoadCertificateAsync();
        }

        //Delete
        private async Task DeleteCertificateAsync()
        {
            await certiticateService.DeleteAsync(SelectedCertificate.CertificateId);
            await LoadCertificateAsync();
        }

        private void OpenPopupSelectFarmID()
        {
            var popupWindow = new SelectFarm()
            {
                DataContext = this
            };
            popupWindow.ShowDialog();
        }

        private async Task SearchCertificateAsync()
        {
          CertificateList = new ObservableCollection<Certificate>(await certiticateService.GetByNameSearch(SearchCertificate))  ;
        }
        #endregion
    }
}
