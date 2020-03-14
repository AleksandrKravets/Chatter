using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.DAL.StoredProcedures.Users;
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
            return _procedureExecutor.ExecuteOneAsync<User>(new GetUserByEmailAndNicknameSP 
            { 
                Email = email, 
                Nickname = nickname 
            });
        }

        public Task<int> CreateAsync(User user)
        {
            return _procedureExecutor.ExecuteAsync(new CreateUserSP 
            { 
                Email = user.Email, 
                Nickname = user.Nickname, 
                HashedPassword = user.HashedPassword 
            });
        }

        public Task<int> DeleteAsync(int userId)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteUserSP 
            { 
                Id = userId 
            });
        }

        public Task<User> GetAsync(int userId)
        {
            return _procedureExecutor.ExecuteOneAsync<User>(new GetUserSP 
            { 
                Id = userId 
            });
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return _procedureExecutor.ExecuteOneAsync<User>(new GetUserByEmailSP 
            { 
                Email = email 
            });
        }

        public Task<User> GetByNicknameAsync(string nickname)
        {
            return _procedureExecutor.ExecuteOneAsync<User>(new GetUserByNicknameSP 
            { 
                Nickname = nickname 
            });
        }

        public Task<int> UpdateAsync(User user)
        {
            return _procedureExecutor.ExecuteAsync(new UpdateUserSP 
            { 
                Id = user.Id, 
                Email = user.Email, 
                Nickname = user.Nickname, 
                HashedPassword = user.HashedPassword 
            });
        }
    }
}
