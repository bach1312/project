using disaster_management.Models;
using disaster_management.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disaster_management.Services
{

    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(int id);
        Task<User> ValidateUser(string username, string password);
        Task<IEnumerable<User>> GetByNameSearch(string keyword);
        Task<IEnumerable<UserMembership>> GetAllMembership();
        Task AddMembership(UserMembership membership);
        Task UpdateMembership(UserMembership membership);

        Task DeleteMembership(int userId);
    }

    public interface IUserRoleService
    {
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole?> GetByIdAsync(int id);
        Task AddAsync(UserRole entity);
        Task UpdateAsync(UserRole entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<UserRole>> GetByNameSearch(string keyword);
    }

    public interface IUserGroupService
    {
        Task<IEnumerable<UserGroup>> GetAllAsync();
        Task<UserGroup?> GetByIdAsync(int id);
        Task AddAsync(UserGroup entity);
        Task UpdateAsync(UserGroup entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<UserGroup>> GetByNameSearch(string keyword);
    }

    public interface IUserLogService
    {
        Task<IEnumerable<UserLog>> GetAllAsync();
        Task<UserLog?> GetByIdAsync(int id);
        Task AddAsync(UserLog entity);
        Task UpdateAsync(UserLog entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<UserLog>> GetByNameSearch(string keyword);
    }



     public class UserService :
        IUserService,
        IUserRoleService,
        IUserGroupService,
        IUserLogService
    {
        private readonly UserRepository userRepository;
        private readonly UserGroupsRepository userGroupsRepository;
        private readonly UserRolesRepository userRoleRepository;
        private readonly UserLogsRepository userLogRepository;

        public UserService(
            UserRepository userRepository,
            UserGroupsRepository userGroupsRepository,
            UserRolesRepository userRoleRepository,
            UserLogsRepository userLogRepository)
        {
            this.userRepository = userRepository;
            this.userGroupsRepository = userGroupsRepository;
            this.userRoleRepository = userRoleRepository;
            this.userLogRepository = userLogRepository;
        }

        async Task IUserService.AddAsync(User entity)
        {
            await userRepository.AddAsync(entity);
        }

        async Task IUserRoleService.AddAsync(UserRole entity)
        {
            await userRoleRepository.AddAsync(entity);
        }

        async Task IUserGroupService.AddAsync(UserGroup entity)
        {
            await userGroupsRepository.AddAsync(entity);
        }

        async Task IUserLogService.AddAsync(UserLog entity)
        {
            await userLogRepository.AddAsync(entity);
        }

        async Task IUserService.AddMembership(UserMembership membership)
        {
            await userRepository.AddMembership(membership);
        }

        async Task IUserService.DeleteAsync(int id)
        {
           await userRepository.DeleteAsync(id);
        }

        async Task IUserRoleService.DeleteAsync(int id)
        {
           await userRoleRepository.DeleteAsync(id);
        }

        async Task IUserGroupService.DeleteAsync(int id)
        {
            await userGroupsRepository.DeleteAsync(id);
        }

        async Task IUserLogService.DeleteAsync(int id)
        {
            await userLogRepository.DeleteAsync(id);
        }

        async Task IUserService.DeleteMembership(int userId)
        {
            await userRepository.DeleteMembership(userId);
        }

        async Task<IEnumerable<User>> IUserService.GetAllAsync()
        {
           return await userRepository.GetAllAsync();
        }

        async Task<IEnumerable<UserRole>> IUserRoleService.GetAllAsync()
        {
           return await userRoleRepository.GetAllAsync();
        }

        async Task<IEnumerable<UserGroup>> IUserGroupService.GetAllAsync()
        {
           return await userGroupsRepository.GetAllAsync();
        }

        async Task<IEnumerable<UserLog>> IUserLogService.GetAllAsync()
        {
           return await userLogRepository.GetAllAsync();
        }

        async Task<IEnumerable<UserMembership>> IUserService.GetAllMembership()
        {
          return  await userRepository.GetAllMembership();
        }

        async Task<User?> IUserService.GetByIdAsync(int id)
        {
           return await userRepository.GetByIdAsync(id);
        }

        async Task<UserRole?> IUserRoleService.GetByIdAsync(int id)
        {
           return await userRoleRepository.GetByIdAsync(id);
        }

        async Task<UserGroup?> IUserGroupService.GetByIdAsync(int id)
        {
           return await userGroupsRepository.GetByIdAsync(id);
        }

        async Task<UserLog?> IUserLogService.GetByIdAsync(int id)
        {
           return await userLogRepository.GetByIdAsync(id);
        }

        async Task<IEnumerable<User>> IUserService.GetByNameSearch(string keyword)
        {
           return await userRepository.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<UserRole>> IUserRoleService.GetByNameSearch(string keyword)
        {
          return await userRoleRepository.GetByNameSearch(keyword);
        }

        Task<IEnumerable<UserGroup>> IUserGroupService.GetByNameSearch(string keyword)
        {
           return userGroupsRepository.GetByNameSearch(keyword);
        }

        async Task<IEnumerable<UserLog>> IUserLogService.GetByNameSearch(string keyword)
        {
           return await userLogRepository.GetByNameSearch(keyword);
        }

        async Task IUserService.UpdateAsync(User entity)
        {
            await userRepository.UpdateAsync(entity);
        }

        async Task IUserRoleService.UpdateAsync(UserRole entity)
        {
           await userRoleRepository.UpdateAsync(entity);
        }

        async Task IUserGroupService.UpdateAsync(UserGroup entity)
        {
            await userGroupsRepository.UpdateAsync(entity);
        }

        async Task IUserLogService.UpdateAsync(UserLog entity)
        {
            await userLogRepository.UpdateAsync(entity);
        }

        async Task IUserService.UpdateMembership(UserMembership membership)
        {
            await userRepository.UpdateMembership(membership);
        }

        async Task<User> IUserService.ValidateUser(string username, string password)
        {
          return await userRepository.ValidateUser(username, password);
        }
    }
}
