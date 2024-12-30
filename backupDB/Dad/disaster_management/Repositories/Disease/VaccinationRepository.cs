using disaster_management.Data;
using disaster_management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.Repositories.Disease
{
    public class VaccinationRepository : Repository<Vaccination>
    {
        private readonly DaDManagementContext _context;
        public VaccinationRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<Vaccination>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.Vaccinations.ToListAsync();
            }
            return await _context.Vaccinations
                .Where(d => EF.Functions.Like(d.VaccineName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
