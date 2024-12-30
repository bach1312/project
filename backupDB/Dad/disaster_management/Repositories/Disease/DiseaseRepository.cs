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

    public class DiseaseRepository : Repository<DiseaseType>
    {
        private readonly DaDManagementContext _context;
        public DiseaseRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

      
        public async Task<IEnumerable<DiseaseType>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.DiseaseTypes.ToListAsync();
            }

            return await _context.DiseaseTypes
                .Where(d => EF.Functions.Like(d.DiseaseName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
