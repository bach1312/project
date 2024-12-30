using disaster_management.Data;
using disaster_management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.Repositories.Livestock
{
    // bác sĩ thú y
    public class VetMedicineAgencyRepository : Repository<VetMedicineAgency>
    {
        private readonly DaDManagementContext _context;
        public VetMedicineAgencyRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<VetMedicineAgency>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.VetMedicineAgencies.ToListAsync();
            }

            return await _context.VetMedicineAgencies
                .Where(d => EF.Functions.Like(d.AgencyName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
