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
            return _procedureExecutor.ExecuteAsync(new CreateTokenSP 
            { 
                Expires = token.Expires,
                Token = token.Token, 
                UserId = token.UserId 
            });
        }

        public Task<int> DeleteRefreshTokenAsync(string refreshToken)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteTokenSP 
            { 
                Token = refreshToken 
            });
        }

        public Task<int> DeleteUserTokenIfExistsAsync(int userId)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteTokenByUserIdSP 
            { 
                UserId = userId
            });
        }

        public Task<RefreshToken> GetTokenAsync(int userId)
        {
            return _procedureExecutor.ExecuteOneAsync<RefreshToken>(new GetTokenByUserIdSP 
            { 
                UserId = userId 
            });
        }
    }
}
