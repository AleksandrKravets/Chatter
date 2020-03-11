using Chatter.Domain.Entities;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Repositories
{
    public interface ITokenRepository
    {
        Task CreateAsync(RefreshToken chat);
        Task DeleteRefreshTokenAsync(string refreshToken);
        Task DeleteUserTokenIfExistsAsync(int userId);
        Task<bool> CheckIfUserTokenValidAsync(int userId, string refreshToken);
    }
}