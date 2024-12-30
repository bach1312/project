using disaster_management.Data;
using disaster_management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.Repositories.Disater
{
    public class DisasterPointRepository : Repository<DisasterPoint>
    {
        private readonly DaDManagementContext _context;
        public DisasterPointRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<DisasterPoint>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.DisasterPoints.ToListAsync();
            }

            return await _context.DisasterPoints
                .Where(d => EF.Functions.Like(d.DisasterType, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
