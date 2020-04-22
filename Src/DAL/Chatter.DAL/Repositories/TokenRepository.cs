using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.DAL.StoredProcedures.Tokens;
using Chatter.Domain.Entities;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly StoredProcedureExecutor _procedureExecutor;

        public TokenRepository(StoredProcedureExecutor procedureExecutor)
        {
            _procedureExecutor = procedureExecutor;
        }

        public Task<int> CreateAsync(RefreshToken token)
        {
        }

        public Task<int> DeleteRefreshTokenAsync(string refreshToken)
        {
        }

        public Task<int> DeleteUserTokenIfExistsAsync(int userId)
        {
        }

        public Task<RefreshToken> GetTokenAsync(int userId)
        {
        }
    }
}
