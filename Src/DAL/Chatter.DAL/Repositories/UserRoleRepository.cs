using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.DAL.StoredProcedures.UserRoles;
using Chatter.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public UserRoleRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task CreateAsync(UserRole userRole)
        {
            return _procedureExecutor.ExecuteAsync(new CreateUserRoleSP 
            { 
                Role = userRole.Role
            });
        }

        public Task DeleteAsync(int userRoleId)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteUserRoleSP
            {
                Id = userRoleId
            });
        }

        public Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return _procedureExecutor.ExecuteListAsync<UserRole>(new GetUsersRolesSP());
        }

        public Task<UserRole> GetAsync(int id)
        {
            return _procedureExecutor.ExecuteOneAsync<UserRole>(new GetUserRoleSP
            {
                Id = id
            });
        }

        public Task UpdateAsync(UserRole userRole)
        {
            return _procedureExecutor.ExecuteAsync(new UpdateUserRoleSP
            {
                Id = userRole.Id, 
                Role = userRole.Role
            });
        }
    }
}
