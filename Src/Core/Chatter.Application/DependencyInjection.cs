using Chatter.Application.Contracts.Factories;
using Chatter.Application.Contracts.Services;
using Chatter.Application.Factories;
using Chatter.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Chatter.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserService, UserService>();
            services.AddSingleton<ITokenFactory, TokenFactory>();

            return services;
        }
    }
}
