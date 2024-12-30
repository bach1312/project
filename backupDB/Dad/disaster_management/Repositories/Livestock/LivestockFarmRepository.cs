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
    public class LivestockFarmRepository : Repository<LivestockFarm>
    {
        private readonly DaDManagementContext _context;
        public LivestockFarmRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<LivestockFarm>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.LivestockFarms.ToListAsync();
            }

            return await _context.LivestockFarms
                .Where(d => EF.Functions.Like(d.FarmName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
