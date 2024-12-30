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
        private PaginationHelper<FileAttachment> _Pagination_FileAttachment;
        public PaginationHelper<FileAttachment> Pagination_FileAttachment
        {
            get => _Pagination_FileAttachment;
            set => SetProperty(ref _Pagination_FileAttachment, value);
        }

        // List
        private ObservableCollection<FileAttachment> _FileAttachmentList;
        public ObservableCollection<FileAttachment> FileAttachmentList
        {
            get { return _FileAttachmentList; }
            set
            {
                if (_FileAttachmentList != value)
                {
                    _FileAttachmentList = value;
                    OnPropertyChanged();
                }
            }
        }

        // FileAttachment
        private FileAttachment _fileAttachment = new();
        public FileAttachment FileAttachment
        {
            get { return _fileAttachment; }
            set
            {
                if (_fileAttachment != value)
                {
                    _fileAttachment = value;
                    OnPropertyChanged();
                }
            }
        }
        // FileAttachment Update
        private FileAttachment _fileAttachmentUpdate = new();
        public FileAttachment FileAttachmentUpdate
        {
            get { return _fileAttachmentUpdate; }
            set
            {
                if (_fileAttachmentUpdate != value)
                {
                    _fileAttachmentUpdate = value;
                    OnPropertyChanged();
                }
            }
        }
        // Selected FileAttachment
        private FileAttachment _selectedFileAttachment;
        public FileAttachment SelectedFileAttachment
        {
            get { return _selectedFileAttachment; }
            set
            {
                if (_selectedFileAttachment != value)
                {
                    _selectedFileAttachment = value;
                    FileAttachmentUpdate = value.Clone();
                    OnPropertyChanged();
                }
            }
        }

        #region Commands

        public IAsyncRelayCommand LoadFileAttachmentCommand { get; private set; }
        public IAsyncRelayCommand AddFileAttachmentCommand { get; private set; }
        public IAsyncRelayCommand UpdateFileAttachmentCommand { get; private set; }
        public IAsyncRelayCommand DeleteFileAttachmentCommand { get; private set; }


        #endregion

        #region Methods

        //Read

        private async Task LoadFileAttachmentAsync()
        {
            try
            {
                FileAttachmentList = new ObservableCollection<FileAttachment>(await fileAttachmentService.GetAllAsync());
                Pagination_FileAttachment = new PaginationHelper<FileAttachment>(FileAttachmentList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Add
        private async Task AddFileAttachmentAsync()
        {
            try
            {
                await fileAttachmentService.AddAsync(FileAttachment.Clone());
                await LoadFileAttachmentAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Update

        private async Task UpdateFileAttachmentAsync()
        {
            try
            {
                await fileAttachmentService.UpdateAsync(FileAttachmentUpdate);
                await LoadFileAttachmentAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Delete

        private async Task DeleteFileAttachmentAsync()
        {
            try
            {
                await fileAttachmentService.DeleteAsync(SelectedFileAttachment.FileId);
                await LoadFileAttachmentAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Search
        private async Task SearchFileAttachmentAsync()
        {
            try
            {
             //   FileAttachmentList = new ObservableCollection<FileAttachment>(await fileAttachmentService.SearchAsync(SearchFileAttachment));
              //  Pagination_FileAttachment = new PaginationHelper<FileAttachment>(FileAttachmentList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

    }
}
