using disaster_management.DTOs;
using disaster_management.Models;
using disaster_management.Repositories.Disease;

namespace disaster_management.Services
{
    public interface IDiseaseTypeService
    {
        Task<IEnumerable<DiseaseType>> GetAllAsync();
        Task<DiseaseType?> GetByIdAsync(int id);
        Task AddAsync(DiseaseType entity);
        Task UpdateAsync(DiseaseType entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<DiseaseType>> GetByNameSearch(string keyword);
    }

    public interface IOutbreakDiagnosisService
    {
        Task<IEnumerable<OutbreakDiagnosis>> GetAllAsync();
        Task<OutbreakDiagnosis?> GetByIdAsync(int id);
        Task AddAsync(OutbreakDiagnosis entity);
        Task UpdateAsync(OutbreakDiagnosis entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<OutbreakDiagnosis>> GetByResultSearch(string keyword);
    }

    public interface IOutbreakService
    {
        Task<IEnumerable<Outbreak>> GetAllAsync();
        Task<Outbreak?> GetByIdAsync(int id);
        Task AddAsync(Outbreak entity);
        Task UpdateAsync(Outbreak entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Outbreak>> GetByNameSearch(string keyword);
    }

    public interface ISymptomService
    {
        Task<IEnumerable<Symptom>> GetAllAsync();
        Task<Symptom?> GetByIdAsync(int id);
        Task AddAsync(Symptom entity);
        Task UpdateAsync(Symptom entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Symptom>> GetByNameSearch(string keyword);
    }

    public interface IVaccinationService
    {
        Task<IEnumerable<Vaccination>> GetAllAsync();
        Task<Vaccination?> GetByIdAsync(int id);
        Task AddAsync(Vaccination entity);
        Task UpdateAsync(Vaccination entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Vaccination>> GetByNameSearch(string keyword);
    }





    public class DiseaseService : IDiseaseTypeService, IOutbreakDiagnosisService, IOutbreakService, ISymptomService, IVaccinationService
    {
        private readonly DiseaseRepository _repositoryDiseaseType;
        private readonly OutbreakDiagnosisRepository _repositoryOutbreakDiagnosis;
        private readonly OutbreakRepository _repositoryOutbreak;
        private readonly SymptomRepository _repositorySymptom;
        private readonly VaccinationRepository _repositoryVaccination;

        public DiseaseService(
            DiseaseRepository repositoryDiseaseType,
            OutbreakDiagnosisRepository outbreakDiagnosisRepository,
            OutbreakRepository outbreakRepository,
            SymptomRepository symptomRepository,
            VaccinationRepository vaccinationRepository

            )
        {
            _repositoryDiseaseType = repositoryDiseaseType;
            _repositoryOutbreakDiagnosis = outbreakDiagnosisRepository;
            _repositoryOutbreak = outbreakRepository;
             _repositorySymptom = symptomRepository;
            _repositoryVaccination = vaccinationRepository;

        }

        #region Kieu dịch bệnh
        async Task<IEnumerable<DiseaseType>> IDiseaseTypeService.GetAllAsync()
        {
            return await _repositoryDiseaseType.GetAllAsync();
        }
        async Task<DiseaseType?> IDiseaseTypeService.GetByIdAsync(int id)
        {
            return await _repositoryDiseaseType.GetByIdAsync(id);
        }
        public async Task AddAsync(DiseaseType entity)
        {
            await _repositoryDiseaseType.AddAsync(entity);
        }
        public async Task UpdateAsync(DiseaseType entity)
        {
            await _repositoryDiseaseType.UpdateAsync(entity);
        }
        public async Task DeleteAsync(int id)
        {
            await _repositoryDiseaseType.DeleteAsync(id);
        }
        async Task<IEnumerable<DiseaseType>> IDiseaseTypeService.GetByNameSearch(string keyword)
        {
            return await _repositoryDiseaseType.GetByNameSearch(keyword);
        }
        #endregion

        #region Chuan doan o dich
        async Task<IEnumerable<OutbreakDiagnosis>> IOutbreakDiagnosisService.GetAllAsync()
        {
            var temp = await _repositoryOutbreakDiagnosis.GetAllAsync();
            return temp;
        }
        async Task<OutbreakDiagnosis?> IOutbreakDiagnosisService.GetByIdAsync(int id)
        {
            return await _repositoryOutbreakDiagnosis.GetByIdAsync(id);
        }
        public async Task AddAsync(OutbreakDiagnosis entity)
        {
            await _repositoryOutbreakDiagnosis.AddAsync(entity);
        }
        public async Task UpdateAsync(OutbreakDiagnosis entity)
        {
            await _repositoryOutbreakDiagnosis.UpdateAsync(entity);
        }
        public async Task<IEnumerable<OutbreakDiagnosis>> GetByResultSearch(string keyword)
        {
            return await _repositoryOutbreakDiagnosis.GetByResultSearch(keyword);
        }
         async Task IOutbreakDiagnosisService.DeleteAsync(int id)
        {
            await _repositoryOutbreakDiagnosis.DeleteAsync(id);
        }
        #endregion

        #region OutBreak

        async Task<IEnumerable<Outbreak>> IOutbreakService.GetAllAsync()
        {
            return await _repositoryOutbreak.GetAllAsync();
        }
        async Task<Outbreak?> IOutbreakService.GetByIdAsync(int id)
        {
            return await _repositoryOutbreak.GetByIdAsync(id);
        }

        public async Task AddAsync(Outbreak entity)
        {
            await _repositoryOutbreak.AddAsync(entity);
        }
        public async Task UpdateAsync(Outbreak entity)
        {
            await _repositoryOutbreak.UpdateAsync(entity);
        }
         async Task IOutbreakService.DeleteAsync(int id)
        {
            await _repositoryOutbreak.DeleteAsync(id);
        }
        async Task<IEnumerable<Outbreak>> IOutbreakService.GetByNameSearch(string keyword)
        {
          return await _repositoryOutbreak.GetByNameSearch(keyword);
        }
        #endregion

        #region Symptom

       
        async Task<IEnumerable<Symptom>> ISymptomService.GetAllAsync()
        {
           return await _repositorySymptom.GetAllAsync();
        }

        async Task<Symptom?> ISymptomService.GetByIdAsync(int id)
        {
            return await _repositorySymptom.GetByIdAsync(id);
        }

        public async Task AddAsync(Symptom entity)
        {
            await _repositorySymptom.AddAsync(entity);
        }

        public async Task UpdateAsync(Symptom entity)
        {
            await _repositorySymptom.UpdateAsync(entity);
        }

        async Task<IEnumerable<Symptom>> ISymptomService.GetByNameSearch(string keyword)
        {
            return await _repositorySymptom.GetByNameSearch(keyword);
        }

        async Task ISymptomService.DeleteAsync(int id)
        {
            await _repositorySymptom.DeleteAsync(id);
        }
        #endregion


        #region Vaccination

        async Task<IEnumerable<Vaccination>> IVaccinationService.GetAllAsync()
        {
            return await _repositoryVaccination.GetAllAsync();
        }
        async Task<Vaccination?> IVaccinationService.GetByIdAsync(int id)
        {
            return await _repositoryVaccination.GetByIdAsync(id);
        }
        public async Task AddAsync(Vaccination entity)
        {
            await _repositoryVaccination.AddAsync(entity);
        }
        public async Task UpdateAsync(Vaccination entity)
        {
            await _repositoryVaccination.UpdateAsync(entity);
        }
        Task<IEnumerable<Vaccination>> IVaccinationService.GetByNameSearch(string keyword)
        {
            return _repositoryVaccination.GetByNameSearch(keyword);
        }
        async Task IVaccinationService.DeleteAsync(int id)
        {
            await _repositoryVaccination.DeleteAsync(id);
        }
        #endregion
    }
}
