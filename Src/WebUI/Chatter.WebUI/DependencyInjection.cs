using Chatter.Common.ConfigurationModels;
using Chatter.WebUI.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quantum.DAL.Infrastructure;

namespace Chatter.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureSetting<DatabaseSettings>(configuration);
            services.ConfigureSetting<JwtSettings>(configuration);
            services.ConfigureSetting<PasswordSettings>(configuration);

            return services;
        }
    }
}
