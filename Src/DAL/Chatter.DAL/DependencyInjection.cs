using Chatter.Application.Contracts.Repositories;
using Chatter.DAL.Infrastructure;
using Chatter.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Chatter.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITokenRepository, TokenRepository>();
            services.AddTransient<IChatUserRepository, ChatUserRepository>();
            services.AddTransient<StoredProcedureExecutor>();

            return services;
        }
    }
}
