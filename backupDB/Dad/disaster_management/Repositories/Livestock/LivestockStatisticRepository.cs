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
    public class LivestockStatisticRepository : Repository<LivestockStatistic>
    {
        private readonly DaDManagementContext _context;
        public LivestockStatisticRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<LivestockStatistic>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.LivestockStatistics.ToListAsync();
            }

            return await _context.LivestockStatistics
                .Where(d => EF.Functions.Like(d.StatisticId.ToString(), $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
