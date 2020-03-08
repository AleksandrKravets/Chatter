using Chatter.Domain.Entities;
using Chatter.WebUI.Factories.Contracts;
using Chatter.WebUI.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chatter.WebUI.Factories.Implementations
{
    public class TokenFactory : ITokenFactory
    {
        private readonly string _secretKey;

        public TokenFactory(string secretKey)
        {
            _secretKey = secretKey;
        }

        //public TokenFactory(IOptions<JwtOptions> jwtOptions)
        //{
        //    this.jwtOptions = jwtOptions.Value;
        //}

        public object GetToken(User user) 
            => new {
                access_token = GetAccessToken(user),
                token_type = JwtBearerDefaults.AuthenticationScheme
            }; 

        private string GetAccessToken(User user)
        {
            var claims = new Claim[] 
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim("email", user.Email),
                new Claim("nickname", user.Nickname),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.Secret));
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                Constants.Issuer,
                Constants.Audience,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(3),
                signingCredentials
            );

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenJson;
        }
    }
}
