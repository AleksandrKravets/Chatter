﻿using Chatter.Application.Contracts.Repositories;
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

        public Task CreateAsync(RefreshToken token)
        {
            return _procedureExecutor.ExecuteAsync(new CreateTokenSP 
            { 
                Expires = token.Expires,
                Token = token.Token, 
                UserId = token.UserId 
            });
        }

        public Task DeleteRefreshTokenAsync(string refreshToken)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteTokenSP 
            { 
                Token = refreshToken 
            });
        }

        public Task DeleteUserTokenIfExistsAsync(int userId)
        {
            return _procedureExecutor.ExecuteAsync(new DeleteTokenByUserIdSP 
            { 
                UserId = userId
            });
        }
    }
}
