using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.Domain.Entities;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public UserRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task<User> GetAsync(string nickname, string email)
        {

        }

        public Task<int> CreateAsync(User user)
        {
        }

        public Task<int> DeleteAsync(int userId)
        {
        }

        public Task<User> GetAsync(int userId)
        {
        }

        public Task<User> GetByEmailAsync(string email)
        {
        }

        public Task<User> GetByNicknameAsync(string nickname)
        {
        }

        public Task<int> UpdateAsync(User user)
        {
        }
    }
}
