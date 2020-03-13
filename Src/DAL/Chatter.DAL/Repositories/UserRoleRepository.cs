using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.Domain.Entities;
using System;
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
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int userRoleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserRole>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserRole> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserRole userRole)
        {
            throw new NotImplementedException();
        }
    }
}
