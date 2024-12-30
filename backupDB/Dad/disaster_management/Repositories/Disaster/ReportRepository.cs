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
    public class ReportRepository : Repository<Report>
    {
        public ReportRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
        }

        internal async Task<IEnumerable<Report>> GetByNameSearch(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
