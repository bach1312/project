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
    public class OutbreakDiagnosisRepository : Repository<OutbreakDiagnosis>
    {
        private readonly DaDManagementContext _context;
        public OutbreakDiagnosisRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<OutbreakDiagnosis>> GetByResultSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.OutbreakDiagnoses.ToListAsync();
            }

            return await _context.OutbreakDiagnoses
                .Where(d => EF.Functions.Like(d.DiagnosisResult, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
