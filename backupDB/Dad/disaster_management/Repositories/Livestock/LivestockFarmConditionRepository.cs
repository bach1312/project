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
    public class LivestockFarmConditionRepository : Repository<LivestockFarmCondition>
    {
        private readonly DaDManagementContext _context;
        public LivestockFarmConditionRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<LivestockFarmCondition>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.LivestockFarmConditions.ToListAsync();
            }

            return await _context.LivestockFarmConditions
                .Where(d => EF.Functions.Like(d.ConditionDetail, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
