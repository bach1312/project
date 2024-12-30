using disaster_management.Models;
using disaster_management.Repositories.Livestock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.Services
{
    public interface ICertificateService
    {
        Task<IEnumerable<Certificate>> GetAllAsync();
        Task<Certificate?> GetByIdAsync(int id);
        Task AddAsync(Certificate entity);
        Task UpdateAsync(Certificate entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Certificate>> GetByNameSearch(string keyword);
    }
    public interface ILivestockFarmService
    {
        Task<IEnumerable<LivestockFarm>> GetAllAsync();
        Task<LivestockFarm?> GetByIdAsync(int id);
        Task AddAsync(LivestockFarm entity);
        Task UpdateAsync(LivestockFarm entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<LivestockFarm>> GetByNameSearch(string keyword);
    }

    public interface ILivestockFarmConditionService
    {
        Task<IEnumerable<LivestockFarmCondition>> GetAllAsync();
        Task<LivestockFarmCondition?> GetByIdAsync(int id);
        Task AddAsync(LivestockFarmCondition entity);
        Task UpdateAsync(LivestockFarmCondition entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<LivestockFarmCondition>> GetByNameSearch(string keyword);
    }
    public interface ILivestockStatisticService
    {
        Task<IEnumerable<LivestockStatistic>> GetAllAsync();
        Task<LivestockStatistic?> GetByIdAsync(int id);
        Task AddAsync(LivestockStatistic entity);
        Task UpdateAsync(LivestockStatistic entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<LivestockStatistic>> GetByNameSearch(string keyword);
    }

    public interface ISafeLivestockZoneService
    {
        Task<IEnumerable<SafeLivestockZone>> GetAllAsync();
        Task<SafeLivestockZone?> GetByIdAsync(int id);
        Task AddAsync(SafeLivestockZone entity);
        Task UpdateAsync(SafeLivestockZone entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<SafeLivestockZone>> GetByNameSearch(string keyword);
    }

    public interface ISlaughterhouseService
    {
        Task<IEnumerable<Slaughterhouse>> GetAllAsync();
        Task<Slaughterhouse?> GetByIdAsync(int id);
        Task AddAsync(Slaughterhouse entity);
        Task UpdateAsync(Slaughterhouse entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Slaughterhouse>> GetByNameSearch(string keyword);

    }
    public interface ITemporaryZoneService
    {
        Task<IEnumerable<TemporaryZone>> GetAllAsync();
        Task<TemporaryZone?> GetByIdAsync(int id);
        Task AddAsync(TemporaryZone entity);
        Task UpdateAsync(TemporaryZone entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TemporaryZone>> GetByNameSearch(string keyword);
    }
    public interface IVeterinaryBranchService
    {
        Task<IEnumerable<VeterinaryBranch>> GetAllAsync();
        Task<VeterinaryBranch?> GetByIdAsync(int id);
        Task AddAsync(VeterinaryBranch entity);
        Task UpdateAsync(VeterinaryBranch entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<VeterinaryBranch>> GetByNameSearch(string keyword);
    }
    public interface IVetMedicineAgencyService
    {
        Task<IEnumerable<VetMedicineAgency>> GetAllAsync();
        Task<VetMedicineAgency?> GetByIdAsync(int id);
        Task AddAsync(VetMedicineAgency entity);
        Task UpdateAsync(VetMedicineAgency entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<VetMedicineAgency>> GetByNameSearch(string keyword);
    }

    public class LivestockService : 
        ICertificateService, 
        ILivestockFarmService, 
        ILivestockFarmConditionService, 
        ILivestockStatisticService, 
        ISafeLivestockZoneService, 
        ISlaughterhouseService,
        ITemporaryZoneService,
        IVeterinaryBranchService,
        IVetMedicineAgencyService
    {
        private readonly CertificateRepository certificateRepository;
        private readonly LivestockFarmRepository livestockFarmRepository;
        private readonly LivestockFarmConditionRepository livestockFarmConditionRepository;
        private readonly LivestockStatisticRepository livestockStatisticRepository;
        private readonly SafeLivestockZoneRepository safeLivestockZoneRepository;
        private readonly SlaughterhouseRepository slaughterhouseRepository;
        private readonly TemporaryZoneRepository temporaryZoneRepository;
        private readonly VeterinaryBranchRepository veterinaryBranchRepository;
        private readonly VetMedicineAgencyRepository vetMedicineAgencyRepository;

        public LivestockService(
            CertificateRepository certificateRepository,
            LivestockFarmRepository livestockFarmRepository,
            LivestockFarmConditionRepository livestockFarmConditionRepository,
            LivestockStatisticRepository livestockStatisticRepository,
            SafeLivestockZoneRepository safeLivestockZoneRepository,
            SlaughterhouseRepository slaughterhouseRepository,
            TemporaryZoneRepository temporaryZoneRepository,
            VeterinaryBranchRepository veterinaryBranchRepository,
            VetMedicineAgencyRepository vetMedicineAgencyRepository
            )
        {
            this.certificateRepository = certificateRepository;
            this.livestockFarmRepository = livestockFarmRepository;
            this.livestockFarmConditionRepository = livestockFarmConditionRepository;
            this.livestockStatisticRepository = livestockStatisticRepository;
            this.safeLivestockZoneRepository = safeLivestockZoneRepository;
            this.slaughterhouseRepository = slaughterhouseRepository;
            this.temporaryZoneRepository = temporaryZoneRepository;
            this.veterinaryBranchRepository = veterinaryBranchRepository;
            this.vetMedicineAgencyRepository = vetMedicineAgencyRepository;

        }

        async Task ICertificateService.AddAsync(Certificate entity)
        {
            await certificateRepository.AddAsync(entity);
        }

        async Task ILivestockFarmService.AddAsync(LivestockFarm entity)
        {
            await livestockFarmRepository.AddAsync(entity);
        }

        async Task ILivestockFarmConditionService.AddAsync(LivestockFarmCondition entity)
        {
            await livestockFarmConditionRepository.AddAsync(entity);
        }

        async Task ILivestockStatisticService.AddAsync(LivestockStatistic entity)
        {
            await livestockStatisticRepository.AddAsync(entity);
        }

        async Task ISafeLivestockZoneService.AddAsync(SafeLivestockZone entity)
        {
            await safeLivestockZoneRepository.AddAsync(entity);
        }

        async Task ISlaughterhouseService.AddAsync(Slaughterhouse entity)
        {
            await slaughterhouseRepository.AddAsync(entity);
        }

        async Task ITemporaryZoneService.AddAsync(TemporaryZone entity)
        {
            await temporaryZoneRepository.AddAsync(entity);
        }

        async Task IVeterinaryBranchService.AddAsync(VeterinaryBranch entity)
        {
            await veterinaryBranchRepository.AddAsync(entity);
        }

        async Task IVetMedicineAgencyService.AddAsync(VetMedicineAgency entity)
        {
            await vetMedicineAgencyRepository.AddAsync(entity);
        }

        async Task ICertificateService.DeleteAsync(int id)
        {
            await certificateRepository.DeleteAsync(id);
        }

        async Task ILivestockFarmService.DeleteAsync(int id)
        {
            await livestockFarmRepository.DeleteAsync(id);
        }

        async Task ILivestockFarmConditionService.DeleteAsync(int id)
        {
            await livestockFarmConditionRepository.DeleteAsync(id);
        }

        async Task ILivestockStatisticService.DeleteAsync(int id)
        {
            await livestockStatisticRepository.DeleteAsync(id);
        }

        async Task ISafeLivestockZoneService.DeleteAsync(int id)
        {
            await safeLivestockZoneRepository.DeleteAsync(id);
        }

        async Task ISlaughterhouseService.DeleteAsync(int id)
        {
            await slaughterhouseRepository.DeleteAsync(id);
        }

        async Task ITemporaryZoneService.DeleteAsync(int id)
        {
            await temporaryZoneRepository.DeleteAsync(id);
        }

        async Task IVeterinaryBranchService.DeleteAsync(int id)
        {
           await veterinaryBranchRepository.DeleteAsync(id);

        }

        async Task IVetMedicineAgencyService.DeleteAsync(int id)
        {
            await vetMedicineAgencyRepository.DeleteAsync(id);

        }

        async Task<IEnumerable<Certificate>> ICertificateService.GetAllAsync()
        {
            return await certificateRepository.GetAllAsync();
        }

        async Task<IEnumerable<LivestockFarm>> ILivestockFarmService.GetAllAsync()
        {
            return await livestockFarmRepository.GetAllAsync();
        }

        async Task<IEnumerable<LivestockFarmCondition>> ILivestockFarmConditionService.GetAllAsync()
        {
            return await livestockFarmConditionRepository.GetAllAsync();
        }

        async Task<IEnumerable<LivestockStatistic>> ILivestockStatisticService.GetAllAsync()
        {
            return await livestockStatisticRepository.GetAllAsync();
        }

        async Task<IEnumerable<SafeLivestockZone>> ISafeLivestockZoneService.GetAllAsync()
        {
            return await safeLivestockZoneRepository.GetAllAsync();
        }

        async Task<IEnumerable<Slaughterhouse>> ISlaughterhouseService.GetAllAsync()
        {
            return await    slaughterhouseRepository.GetAllAsync();
        }

        async Task<IEnumerable<TemporaryZone>> ITemporaryZoneService.GetAllAsync()
        {
            return await temporaryZoneRepository.GetAllAsync();
        }

        async Task<IEnumerable<VeterinaryBranch>> IVeterinaryBranchService.GetAllAsync()
        {
            return await veterinaryBranchRepository.GetAllAsync();
        }

        async Task<IEnumerable<VetMedicineAgency>> IVetMedicineAgencyService.GetAllAsync()
        {
           return await vetMedicineAgencyRepository.GetAllAsync();
        }

        async Task<Certificate?> ICertificateService.GetByIdAsync(int id)
        {
           return await certificateRepository.GetByIdAsync(id);
        }

        async Task<LivestockFarm?> ILivestockFarmService.GetByIdAsync(int id)
        {
            return await livestockFarmRepository.GetByIdAsync(id);
        }

        async Task<LivestockFarmCondition?> ILivestockFarmConditionService.GetByIdAsync(int id)
        {
            return await livestockFarmConditionRepository.GetByIdAsync(id);
        }

        async Task<LivestockStatistic?> ILivestockStatisticService.GetByIdAsync(int id)
        {
            return await livestockStatisticRepository.GetByIdAsync(id);
        }

        async Task<SafeLivestockZone?> ISafeLivestockZoneService.GetByIdAsync(int id)
        {
            return await safeLivestockZoneRepository.GetByIdAsync(id);
        }

        async Task<Slaughterhouse?> ISlaughterhouseService.GetByIdAsync(int id)
        {
            return await slaughterhouseRepository.GetByIdAsync(id);
        }

        async Task<TemporaryZone?> ITemporaryZoneService.GetByIdAsync(int id)
        {
            return await temporaryZoneRepository.GetByIdAsync(id);
        }

        async Task<VeterinaryBranch?> IVeterinaryBranchService.GetByIdAsync(int id)
        {
            return await veterinaryBranchRepository.GetByIdAsync(id);
        }

        async Task<VetMedicineAgency?> IVetMedicineAgencyService.GetByIdAsync(int id)
        {
            return await vetMedicineAgencyRepository.GetByIdAsync(id);
        }

        async Task<IEnumerable<Certificate>> ICertificateService.GetByNameSearch(string keyword)
        {
            return await certificateRepository.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<LivestockFarm>> ILivestockFarmService.GetByNameSearch(string keyword)
        {
           return await livestockFarmRepository.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<LivestockFarmCondition>> ILivestockFarmConditionService.GetByNameSearch(string keyword)
        {
            return await livestockFarmConditionRepository.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<LivestockStatistic>> ILivestockStatisticService.GetByNameSearch(string keyword)
        {
            return await livestockStatisticRepository.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<SafeLivestockZone>> ISafeLivestockZoneService.GetByNameSearch(string keyword)
        {
           return await safeLivestockZoneRepository.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<Slaughterhouse>> ISlaughterhouseService.GetByNameSearch(string keyword)
        {
            return await slaughterhouseRepository.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<TemporaryZone>> ITemporaryZoneService.GetByNameSearch(string keyword)
        {
           return await temporaryZoneRepository.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<VeterinaryBranch>> IVeterinaryBranchService.GetByNameSearch(string keyword)
        {
            return await veterinaryBranchRepository.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<VetMedicineAgency>> IVetMedicineAgencyService.GetByNameSearch(string keyword)
        {
            return await vetMedicineAgencyRepository.GetByNameSearch(keyword);
        }

        async Task ICertificateService.UpdateAsync(Certificate entity)
        {
             await certificateRepository.UpdateAsync(entity);
        }

        async Task ILivestockFarmService.UpdateAsync(LivestockFarm entity)
        {
           await livestockFarmRepository.UpdateAsync(entity);
        }

        async Task ILivestockFarmConditionService.UpdateAsync(LivestockFarmCondition entity)
        {
            await livestockFarmConditionRepository.UpdateAsync(entity);
        }

        async Task ILivestockStatisticService.UpdateAsync(LivestockStatistic entity)
        {
            await livestockStatisticRepository.UpdateAsync(entity);
        }

        async Task ISafeLivestockZoneService.UpdateAsync(SafeLivestockZone entity)
        {
           await safeLivestockZoneRepository.UpdateAsync(entity);
        }

        async Task ISlaughterhouseService.UpdateAsync(Slaughterhouse entity)
        {
            await slaughterhouseRepository.UpdateAsync(entity);
        }

        async Task ITemporaryZoneService.UpdateAsync(TemporaryZone entity)
        {
            await temporaryZoneRepository.UpdateAsync(entity);
        }

        async Task IVeterinaryBranchService.UpdateAsync(VeterinaryBranch entity)
        {
            await veterinaryBranchRepository.UpdateAsync(entity);
        }

        async Task IVetMedicineAgencyService.UpdateAsync(VetMedicineAgency entity)
        {
            await vetMedicineAgencyRepository.UpdateAsync(entity);
        }
    }
}
