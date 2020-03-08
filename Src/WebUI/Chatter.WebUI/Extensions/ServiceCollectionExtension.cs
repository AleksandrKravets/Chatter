using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Chatter.WebUI.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureSetting<TOptions>(this IServiceCollection services, IConfiguration configuration) where TOptions : class
        {
            string sectionName = typeof(TOptions).Name;
            IConfigurationSection section = configuration.GetSection(sectionName);
            services.Configure<TOptions>(section);
        }

        public static void ConfigureWithEnvironmentVariables<TEntity>(this IServiceCollection services, IConfiguration configuration) where TEntity : class
        {
            var typeProperties = typeof(TEntity).GetProperties();

            if (EnvironmentVariablesExist(typeProperties.Select(p => p.Name).ToArray()))
            {
                services.Configure<TEntity>(c => {
                    foreach (var property in typeProperties)
                    {
                        property.SetValue(c, Convert.ChangeType(Environment.GetEnvironmentVariable(property.Name), property.PropertyType));
                    }
                });
            } else
            {
                services.ConfigureSetting<TEntity>(configuration);
            }
        }

        private static bool EnvironmentVariablesExist(params string[] variablesNames)
        {
            foreach (var variableName in variablesNames)
                if (Environment.GetEnvironmentVariable(variableName) == null)
                    return false;

            return true;
        }
    }
}
