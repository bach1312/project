using disaster_management.Models;
using disaster_management.Repositories.Disater;

namespace disaster_management.Services
{

    public interface IDisasterPointService
    {
        Task<IEnumerable<DisasterPoint>> GetAllAsync();
        Task<DisasterPoint?> GetByIdAsync(int id);
        Task AddAsync(DisasterPoint entity);
        Task UpdateAsync(DisasterPoint entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<DisasterPoint>> GetByNameSearch(string keyword);
    }
    public interface IFileAttachmentService
    {
        Task<IEnumerable<FileAttachment>> GetAllAsync();
        Task<FileAttachment?> GetByIdAsync(int id);
        Task AddAsync(FileAttachment entity);
        Task UpdateAsync(FileAttachment entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<FileAttachment>> GetByNameSearch(string keyword);
    }
    public interface IReportService
    {
        Task<IEnumerable<Report>> GetAllAsync();
        Task<Report?> GetByIdAsync(int id);
        Task AddAsync(Report entity);
        Task UpdateAsync(Report entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Report>> GetByNameSearch(string keyword);
    }
    public class DisasterService : IDisasterPointService, IFileAttachmentService, IReportService
    {

        private readonly DisasterPointRepository disasterPointRepository;
        private readonly FileAttachmentRepository fileAttachmentRepository;
        private readonly ReportRepository reportRepository;

        public DisasterService(DisasterPointRepository disasterPointRepository,
            FileAttachmentRepository fileAttachmentRepository,
            ReportRepository reportRepository)
        {
            this.disasterPointRepository = disasterPointRepository;
            this.fileAttachmentRepository = fileAttachmentRepository;
            this.reportRepository = reportRepository;
        }

        #region Implementation
        async Task IDisasterPointService.AddAsync(DisasterPoint entity)
        {
          await disasterPointRepository.AddAsync(entity);
        }

        async Task IFileAttachmentService.AddAsync(FileAttachment entity)
        {
            await fileAttachmentRepository.AddAsync(entity);
        }

        async Task IReportService.AddAsync(Report entity)
        {
            await reportRepository.AddAsync(entity);
        }

        async Task IDisasterPointService.DeleteAsync(int id)
        {
            await disasterPointRepository.DeleteAsync(id);
        }

        async Task IFileAttachmentService.DeleteAsync(int id)
        {
            await fileAttachmentRepository.DeleteAsync(id);
        }

        async Task IReportService.DeleteAsync(int id)
        {
            await reportRepository.DeleteAsync(id);
        }

        async Task<IEnumerable<DisasterPoint>> IDisasterPointService.GetAllAsync()
        {
           return await disasterPointRepository.GetAllAsync();
        }

        async Task<IEnumerable<FileAttachment>> IFileAttachmentService.GetAllAsync()
        {
            return await fileAttachmentRepository.GetAllAsync();
        }

        async Task<IEnumerable<Report>> IReportService.GetAllAsync()
        {
            return await reportRepository.GetAllAsync();
        }

        async Task<DisasterPoint?> IDisasterPointService.GetByIdAsync(int id)
        {
           return await disasterPointRepository.GetByIdAsync(id);
        }

        async Task<FileAttachment?> IFileAttachmentService.GetByIdAsync(int id)
        {
            return await fileAttachmentRepository.GetByIdAsync(id);
        }

        Task<Report?> IReportService.GetByIdAsync(int id)
        {
           return reportRepository.GetByIdAsync(id);
        }

        async Task<IEnumerable<DisasterPoint>> IDisasterPointService.GetByNameSearch(string keyword)
        {
             return await disasterPointRepository.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<FileAttachment>> IFileAttachmentService.GetByNameSearch(string keyword)
        {
            return await fileAttachmentRepository.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<Report>> IReportService.GetByNameSearch(string keyword)
        {
            return await reportRepository.GetByNameSearch(keyword);
        }

        async Task IDisasterPointService.UpdateAsync(DisasterPoint entity)
        {
             await disasterPointRepository.UpdateAsync(entity);
        }

        async Task IFileAttachmentService.UpdateAsync(FileAttachment entity)
        {
            await fileAttachmentRepository.UpdateAsync(entity);
        }

        async Task IReportService.UpdateAsync(Report entity)
        {
           await reportRepository.UpdateAsync(entity);
        }
        #endregion


    }
}
