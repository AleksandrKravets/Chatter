using Chatter.Application.Contracts.Services;
using Chatter.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Chatter.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IMessageService, MessageService>();

            return services;
        }
    }
}
