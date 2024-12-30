using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using disaster_management.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.ViewModels.ChildViewModels.Disaster
{
    public partial class DisasterViewModel : ObservableObject
    {
        private readonly IDisasterPointService disasterPointService;
        private readonly IFileAttachmentService fileAttachmentService;
        private readonly IReportService reportService;

        public DisasterViewModel(IDisasterPointService disasterPointService, IFileAttachmentService fileAttachmentService, IReportService reportService )
        {
             this.disasterPointService = disasterPointService;
            this.fileAttachmentService = fileAttachmentService;
            this.reportService = reportService;

            // Disaster Point
            LoadDisasterPointCommand = new AsyncRelayCommand(LoadDisasterPointAsync);
            AddDisasterPointCommand = new AsyncRelayCommand(AddDisasterPointAsync);
            UpdateDisasterPointCommand = new AsyncRelayCommand(UpdateDisasterPointAsync);
            DeleteDisasterPointCommand = new AsyncRelayCommand(DeleteDisasterPointAsync);
            SearchDisasterPointCommand = new AsyncRelayCommand(SearchDisasterPointAsync);

            // File Attachment
            LoadFileAttachmentCommand = new AsyncRelayCommand(LoadFileAttachmentAsync);
            AddFileAttachmentCommand = new AsyncRelayCommand(AddFileAttachmentAsync);
            UpdateFileAttachmentCommand = new AsyncRelayCommand(UpdateFileAttachmentAsync);
            DeleteFileAttachmentCommand = new AsyncRelayCommand(DeleteFileAttachmentAsync);

            // Report
            LoadReportCommand = new AsyncRelayCommand(LoadReportAsync);
            AddReportCommand = new AsyncRelayCommand(AddReportAsync);
            UpdateReportCommand = new AsyncRelayCommand(UpdateReportAsync);
            DeleteReportCommand = new AsyncRelayCommand(DeleteReportAsync);

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
           await LoadDisasterPointCommand.ExecuteAsync(null);
           await LoadFileAttachmentCommand.ExecuteAsync(null);
           await LoadReportCommand.ExecuteAsync(null);

        }
    }
}
