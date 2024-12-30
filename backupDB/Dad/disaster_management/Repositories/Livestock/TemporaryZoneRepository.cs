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
    public class TemporaryZoneRepository : Repository<TemporaryZone>
    {
        private readonly DaDManagementContext _context;
        public TemporaryZoneRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<TemporaryZone>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.TemporaryZones.ToListAsync();
            }

            return await _context.TemporaryZones
                .Where(d => EF.Functions.Like(d.ZoneName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
