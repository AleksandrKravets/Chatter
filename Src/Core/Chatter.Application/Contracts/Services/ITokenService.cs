using Chatter.Domain.Dto;
using Chatter.Domain.Entities;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Chatter.Application.Contracts.Services
{
    public interface ITokenService
    {
        Task<TokensResponseModel> GetTokensAsync(User user);
        Task<Result<TokensResponseModel>> RefreshTokenAsync(string refreshToken, string accessToken);
    }
}
