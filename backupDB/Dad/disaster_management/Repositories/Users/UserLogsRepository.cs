using disaster_management.Data;
using disaster_management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.Repositories.Users
{
    public class UserLogsRepository : Repository<UserLog>
    {
        private readonly DaDManagementContext _context;
        public UserLogsRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            _context = new DaDManagementContext(context);
        }

        public async Task<IEnumerable<UserLog>> GetByNameSearch(string keyword)
        {
            throw new NotImplementedException();
        }

      

    }
}
