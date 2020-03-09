using Chatter.Domain.Entities;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface ITokenService
    {
        bool HasValidRefreshToken(int userId, string refreshToken);
        Task AddRefreshTokenAsync(RefreshToken refreshToken);
        Task RemoveRefreshTokenAsync(string refreshToken);
        Task RemoveUserRefreshTokenAsync(int userId);
    }
}
