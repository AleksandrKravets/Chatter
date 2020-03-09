using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Chatter.WebUI.Infrastructure
{
    internal class JwtAuthParameters : TokenValidationParameters
    {
        public JwtAuthParameters(string key)
        {
            ValidateAudience = true;
            ValidateIssuer = true;
            ValidateIssuerSigningKey = true;
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            RequireExpirationTime = true;
            ValidateLifetime = true;
            ClockSkew = TimeSpan.Zero;
        }
    }
}
