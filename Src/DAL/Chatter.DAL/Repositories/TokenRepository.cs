using Chatter.Application.Contracts.Repositories;
using Chatter.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Chatter.DAL.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly string _connectionString;

        public TokenRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<bool> CheckIfUserTokenValidAsync(int userId, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(RefreshToken chat)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserTokenIfExistsAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
