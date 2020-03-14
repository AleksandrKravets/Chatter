﻿using Chatter.Application.Contracts.Factories;
using Chatter.Application.Contracts.Repositories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Helpers;
using Chatter.Application.Infrastructure;
using Chatter.Common.ConfigurationModels;
using Chatter.Domain.Dto;
using Chatter.Domain.Entities;
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
        private readonly ITokenRepository _tokenRepository;

        public TokenService(
            ITokenFactory tokenFactory,
            IUserService userService,
            ITokenRepository tokenRepository,
            IOptions<JwtSettings> jwtSettings)
        {
            _tokenRepository = tokenRepository;
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

        public async Task<ResponseObject> RefreshTokenAsync(string refreshToken, string accessToken)
        {
            var principalResult = JwtHelper.GetPrincipalFromExpiredToken(accessToken, _jwtSettings.SecretKey);

            if (principalResult.IsSuccess)
            {
                var userId = principalResult.Value.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);

                if (userId != null)
                {
                    var user = await _userService.GetAsync(Convert.ToInt32(userId.Value));

                    if (user != null)
                    {
                        if (await CheckIfUserTokenValidAsync(user.Id, refreshToken))
                        {
                            await RemoveRefreshTokenAsync(refreshToken);

                            var result = new TokensResponseModel
                            {
                                AccessToken = _tokenFactory.GetAccessToken(user),
                                RefreshToken = _tokenFactory.GetRefreshToken()
                            };

                            await AddRefreshTokenAsync(result.RefreshToken.Token, result.RefreshToken.Expires, user.Id);

                            return new ResponseObject
                            {
                                Result = result,
                                Status = ResponseStatus.Success
                            };
                        }
                    }

                }
            }

            return new ResponseObject
            {
                Result = null,
                Status = ResponseStatus.Failure
            };
        }

        private Task RemoveUserTokenIfExistsAsync(int userId)
        {
            return _tokenRepository.DeleteUserTokenIfExistsAsync(userId);
        }

        private Task RemoveRefreshTokenAsync(string refreshToken)
        {
            return _tokenRepository.DeleteRefreshTokenAsync(refreshToken);
        }

        private Task AddRefreshTokenAsync(string refreshToken, DateTime expires, int userId)
        {
            return _tokenRepository.CreateAsync(new Domain.Entities.RefreshToken 
            { 
                Token = refreshToken, 
                Expires = expires, 
                UserId = userId 
            });
        }

        private async Task<bool> CheckIfUserTokenValidAsync(int userId, string refreshToken)
        {
            var token = await _tokenRepository.GetTokenAsync(userId);
            return token.Active && token.Token == refreshToken;
        }
    }
}
