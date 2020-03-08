using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Chatter.WebUI.Infrastructure
{
    internal class JwtAuthParameters : TokenValidationParameters
    {
        public JwtAuthParameters(string key)
        {
            // будет ли валидироваться потребитель токена
            ValidateAudience = false;
            // укзывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = false;
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true;
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));

            RequireExpirationTime = true;
            // будет ли валидироваться время существования
            ValidateLifetime = true;

            ClockSkew = TimeSpan.Zero;
        }
    }
}
