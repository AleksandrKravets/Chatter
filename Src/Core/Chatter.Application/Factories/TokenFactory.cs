using Chatter.Application.Contracts.Factories;
using Chatter.Common.ConfigurationModels;
using Chatter.Domain.Dto;
using Chatter.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Chatter.Application.Factories
{
    public class TokenFactory : ITokenFactory
    {
        private readonly JwtSettings _jwtSettings;

        public TokenFactory(IOptions<JwtSettings> jwtSettings)
        {
            this._jwtSettings = jwtSettings.Value;
        }

        public Domain.Dto.RefreshToken GetRefreshToken(int size)
        {
            var randomNumber = new byte[size];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return new Domain.Dto.RefreshToken
                {
                    Token = Convert.ToBase64String(randomNumber),
                    Expires = DateTime.Now.AddMinutes(_jwtSettings.RefreshTokenLifetime)
                };
            }
        }

        public AccessToken GetAccessToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(3),
                signingCredentials
            );

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new AccessToken
            {
                Token = accessToken,
                Expires = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenLifetime)
            };
        }
    }
}
