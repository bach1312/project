using disaster_management.Data;
using disaster_management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.Repositories.Disease
{
    public class OutbreakRepository : Repository<Outbreak>
    {
        private readonly DaDManagementContext _context;
        public OutbreakRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<Outbreak>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.Outbreaks.ToListAsync();
            }

            return await _context.Outbreaks
                .Where(d => EF.Functions.Like(d.OutbreakName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
