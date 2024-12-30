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
    public class SafeLivestockZoneRepository : Repository<SafeLivestockZone>
    {
        private readonly DaDManagementContext _context;
        public SafeLivestockZoneRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        internal async Task<IEnumerable<SafeLivestockZone>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.SafeLivestockZones.ToListAsync();
            }

            return await _context.SafeLivestockZones
                .Where(d => EF.Functions.Like(d.ZoneName, $"%{keyword}%"))
                .ToListAsync();
        }
    }

}
