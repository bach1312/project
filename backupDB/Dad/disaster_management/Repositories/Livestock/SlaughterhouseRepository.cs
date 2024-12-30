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
    public class SlaughterhouseRepository : Repository<Slaughterhouse>
    {
        private readonly DaDManagementContext _context;
        public SlaughterhouseRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<Slaughterhouse>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.Slaughterhouses.ToListAsync();
            }

            return await _context.Slaughterhouses
                .Where(d => EF.Functions.Like(d.SlaughterhouseName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
