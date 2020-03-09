using CSharpFunctionalExtensions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chatter.WebUI.Helpers
{
    public class JwtHelper
    {
        public static Result<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token, string signingKey)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey)),
                ValidateLifetime = true,
                RequireExpirationTime = true, 
                ClockSkew = TimeSpan.Zero
        };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;


            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                return Result.Failure<ClaimsPrincipal>("Invalid token");

            return Result.Ok(principal);
        }
    }
}
