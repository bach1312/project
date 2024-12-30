using disaster_management.Data;
using disaster_management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.Repositories.Location
{
    public class DistrictsRepository : Repository<District>
    {
        private readonly DaDManagementContext _context;
        public DistrictsRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<District>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.Districts.ToListAsync();
            }

            return await _context.Districts
                .Where(d => EF.Functions.Like(d.DistrictName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
