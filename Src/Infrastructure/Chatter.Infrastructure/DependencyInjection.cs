using Chatter.Application.Contracts.Repositories;
using Chatter.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Chatter.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
