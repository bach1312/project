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
    public class CertificateRepository : Repository<Certificate>
    {
        private readonly DaDManagementContext _context;
        public CertificateRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<Certificate>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await _context.Certificates.ToListAsync();
            }

            return await _context.Certificates
                .Where(d => EF.Functions.Like(d.CertificateName, $"%{keyword}%"))
                .ToListAsync();
        }
    }
}
