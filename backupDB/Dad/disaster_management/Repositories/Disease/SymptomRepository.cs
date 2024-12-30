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
    public class SymptomRepository : Repository<Symptom>
    {
        private readonly DaDManagementContext _context;
        public SymptomRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<Symptom>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.Symptoms.ToListAsync();
            }
            return await _context.Symptoms
                .Where(d => EF.Functions.Like(d.SymptomName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
