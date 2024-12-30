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
    //Chi nhánh thú y
    public class VeterinaryBranchRepository : Repository<VeterinaryBranch>
    {
        private readonly DaDManagementContext _context;
        public VeterinaryBranchRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<VeterinaryBranch>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.VeterinaryBranches.ToListAsync();
            }

            return await _context.VeterinaryBranches
                .Where(d => EF.Functions.Like(d.BranchName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}

// Slaughter house