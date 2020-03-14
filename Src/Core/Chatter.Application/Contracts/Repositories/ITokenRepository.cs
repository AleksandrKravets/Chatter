using Chatter.Domain.Entities;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface ITokenRepository
    {
        Task CreateAsync(RefreshToken token);
        Task DeleteRefreshTokenAsync(string refreshToken);
        Task DeleteUserTokenIfExistsAsync(int userId);
        Task<RefreshToken> GetTokenAsync(int userId);
    }
}