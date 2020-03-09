using Chatter.Application.Contracts.Services;
using Chatter.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{

    public class TokenService : ITokenService
    {
        public bool HasValidRefreshToken(int userId, string refreshToken)
        {
            // Check if user has valid refresh token (user.Token == refreshToken && rt.Active)
            return true;
        }

        public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
        {
            


            // add this token to refresh tokens table
        }

        public async Task RemoveRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveUserRefreshTokenAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
