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
    public class WardsRepository : Repository<Ward>
    {
        private readonly DaDManagementContext _context;
        public WardsRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<Ward>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.Wards.ToListAsync();
            }

            return await _context.Wards
                .Where(d => EF.Functions.Like(d.WardName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
