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
    public class ProvincesRepository : Repository<Province>
    {
        private readonly DaDManagementContext _context;
        public ProvincesRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<Province>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.Provinces.ToListAsync();
            }

            return await _context.Provinces
                .Where(d => EF.Functions.Like(d.ProvinceName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
