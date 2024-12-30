using disaster_management.Models;
using disaster_management.Repositories.Location;

namespace disaster_management.Services
{
    public interface IDistrictsService
    {
        Task<IEnumerable<District>> GetAllAsync();
        Task<District?> GetByIdAsync(int id);
        Task AddAsync(District entity);
        Task UpdateAsync(District entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<District>> GetByNameSearch(string keyword);
    }
    public interface IProvincesService
    {
        Task<IEnumerable<Province>> GetAllAsync();
        Task<Province?> GetByIdAsync(int id);
        Task AddAsync(Province entity);
        Task UpdateAsync(Province entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Province>> GetByNameSearch(string keyword);
    }
    public interface IWardsService
    {
        Task<IEnumerable<Ward>> GetAllAsync();
        Task<Ward?> GetByIdAsync(int id);
        Task AddAsync(Ward entity);
        Task UpdateAsync(Ward entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Ward>> GetByNameSearch(string keyword);
    }
    public class LocationService : IDistrictsService, IProvincesService, IWardsService
    {
        private readonly DistrictsRepository districtsService;
        private readonly ProvincesRepository provincesService;
        private readonly WardsRepository wardsService;

        public LocationService(
            DistrictsRepository districtsService,
            ProvincesRepository provincesService,
            WardsRepository wardsService)

        {
            this.provincesService = provincesService;
            this.districtsService = districtsService;
            this.wardsService = wardsService;
        }

        async Task IDistrictsService.AddAsync(District entity)
        {
            await districtsService.AddAsync(entity);
        }

        async Task IProvincesService.AddAsync(Province entity)
        {
           await provincesService.AddAsync(entity);
        }

        async Task IWardsService.AddAsync(Ward entity)
        {
            await wardsService.AddAsync(entity);
        }

        async Task IDistrictsService.DeleteAsync(int id)
        {
            await districtsService.DeleteAsync(id);
        }

        async Task IProvincesService.DeleteAsync(int id)
        {
           await provincesService.DeleteAsync(id);
        }

        async Task IWardsService.DeleteAsync(int id)
        {
            await wardsService.DeleteAsync(id);
        }

        async Task<IEnumerable<District>> IDistrictsService.GetAllAsync()
        {
           return await districtsService.GetAllAsync();
        }

        async Task<IEnumerable<Province>> IProvincesService.GetAllAsync()
        {
          return await provincesService.GetAllAsync();
        }

        async Task<IEnumerable<Ward>> IWardsService.GetAllAsync()
        {
          return  await wardsService.GetAllAsync();
        }

        async Task<District?> IDistrictsService.GetByIdAsync(int id)
        {
          return  await districtsService.GetByIdAsync(id);
        }

        async Task<Province?> IProvincesService.GetByIdAsync(int id)
        {
           return  await provincesService.GetByIdAsync(id);
        }

        async Task<Ward?> IWardsService.GetByIdAsync(int id)
        {
            return await wardsService.GetByIdAsync(id);
        }

        async Task<IEnumerable<District>> IDistrictsService.GetByNameSearch(string keyword)
        {
            return await districtsService.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<Province>> IProvincesService.GetByNameSearch(string keyword)
        {
            return await provincesService.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<Ward>> IWardsService.GetByNameSearch(string keyword)
        {
          return  await wardsService.GetByNameSearch(keyword);
        }

        async Task IDistrictsService.UpdateAsync(District entity)
        {
            await districtsService.UpdateAsync(entity);
        }

        async Task IProvincesService.UpdateAsync(Province entity)
        {
            await provincesService.UpdateAsync(entity);
        }

        async Task IWardsService.UpdateAsync(Ward entity)
        {
           await wardsService.UpdateAsync(entity);
        }
    }
}
