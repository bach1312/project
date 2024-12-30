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
    public class UserRepository : Repository<User>
    {
        private readonly DaDManagementContext context;
        public UserRepository(DbContextOptions<DaDManagementContext> context) : base(context)
        {
            this.context = new DaDManagementContext(context);
        }

        public async Task<User?> ValidateUser(string username, string password)
        {
            // Replace with hashed password comparison in production
            var user = await context.Users.SingleOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);

            if (user == null) return null;
            // Tìm nhóm của user
            var group = await context.UserGroups
                .FirstOrDefaultAsync(gr => gr.Users.Any(u => u.UserId == user.UserId));
            // Tìm role của nhóm
            var role = await context.UserRoles
                .FirstOrDefaultAsync(r => r.Groups.Any(g => g.GroupId == group.GroupId));
            group.Roles.Add(role);
            user.Groups.Add(group);

            return user;
        }


        public async Task<IEnumerable<User>> GetByNameSearch(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return await context.Users.ToListAsync();
            }

            return await context.Users
                .Where(d => EF.Functions.Like(d.Username, $"%{keyword}%"))
                .ToListAsync();
        }

        // Lấy tất cả UserMembership
        public async Task<IEnumerable<UserMembership>> GetAllMembership()
        {
            var sqlQuery = "SELECT * FROM UserGroupMembership";
            return await context.Set<UserMembership>().FromSqlRaw(sqlQuery).ToListAsync();
        }

        // Thêm mới UserMembership
        public async Task AddMembership(UserMembership membership)
        {
            var sqlQuery = "INSERT INTO UserGroupMembership (UserId, GroupId) VALUES (@p0, @p1)";
            await context.Database.ExecuteSqlRawAsync(sqlQuery, membership.UserId, membership.GroupId);
        }

        // Cập nhật UserMembership
        public async Task UpdateMembership(UserMembership membership)
        {
            var sqlQuery = "UPDATE UserGroupMembership SET GroupId = @p1 WHERE UserId = @p0";
            await context.Database.ExecuteSqlRawAsync(sqlQuery, membership.UserId, membership.GroupId);
        }

        // Xóa UserMembership
        public async Task DeleteMembership(int userId)
        {
            var sqlQuery = "DELETE FROM UserGroupMembership WHERE UserId = @p0";
            await context.Database.ExecuteSqlRawAsync(sqlQuery, userId);
        }


    }
}
