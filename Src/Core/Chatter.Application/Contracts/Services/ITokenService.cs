using Chatter.Application.Infrastructure;
using Chatter.Domain.Dto;
using Chatter.Domain.Entities;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface ITokenService
    {
        Task<TokensResponseModel> GetTokensAsync(User user);
        Task<ResponseObject> RefreshTokenAsync(string refreshToken, string accessToken);
        //Task<bool> CheckIfUserTokenValidAsync(int userId, string refreshToken);
    }
}
