using Chatter.Application.Contracts.Factories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Helpers;
using Chatter.Common.ConfigurationModels;
using Chatter.Domain.Dto;
using Chatter.Domain.Entities;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Chatter.Application.Services
{

    public class TokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IUserService _userService;
        private readonly ITokenFactory _tokenFactory;

        public TokenService(
            ITokenFactory tokenFactory,
            IUserService userService,
            IOptions<JwtSettings> jwtSettings)
        {
            _tokenFactory = tokenFactory;
            _userService = userService;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<TokensResponseModel> GetTokensAsync(User user)
        {
            await RemoveUserTokenIfExistsAsync(user.Id);

            var response = new TokensResponseModel
            {
                AccessToken = _tokenFactory.GetAccessToken(user),
                RefreshToken = _tokenFactory.GetRefreshToken()
            };

            await AddRefreshTokenAsync(response.RefreshToken.Token, response.RefreshToken.Expires, user.Id);

            return response;
        }

        public async Task<Result<TokensResponseModel>> RefreshTokenAsync(string refreshToken, string accessToken)
        {
            var principalResult = JwtHelper.GetPrincipalFromExpiredToken(accessToken, _jwtSettings.SecretKey);

            if (principalResult.IsSuccess)
            {
                var userId = principalResult.Value.Claims.First(c => c.Type == JwtRegisteredClaimNames.Sub);

                var user = await _userService.GetAsync(Convert.ToInt32(userId.Value));

                if (user != null)
                {
                    if (await HasValidRefreshTokenAsync(user.Id, refreshToken))
                    {
                        await RemoveRefreshTokenAsync(refreshToken);

                        var response = new TokensResponseModel
                        {
                            AccessToken = _tokenFactory.GetAccessToken(user),
                            RefreshToken = _tokenFactory.GetRefreshToken()
                        };

                        await AddRefreshTokenAsync(response.RefreshToken.Token, response.RefreshToken.Expires, user.Id);

                        return Result.Ok(response);
                    }
                }
            }

            return Result.Failure<TokensResponseModel>("Refresh token error.");
        }

        private Task RemoveUserTokenIfExistsAsync(int userId)
        {
            throw new NotImplementedException();
        }

        private async Task RemoveRefreshTokenAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        private async Task AddRefreshTokenAsync(string refreshToken, DateTime expires, int userId)
        {
            throw new NotImplementedException();
        }

        private async Task<bool> HasValidRefreshTokenAsync(int userId, string refreshToken)
        {
            // Check if user has valid refresh token (user.Token == refreshToken && rt.Active)
            // проверить есть ли в наличии в бд старый токен
            return true;
        }
    }
}
