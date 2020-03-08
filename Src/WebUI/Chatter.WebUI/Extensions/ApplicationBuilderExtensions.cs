using Chatter.WebUI.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Chatter.WebUI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
            => app.UseMiddleware<ExceptionHandlingMiddleware>();

        public static IApplicationBuilder UseCheckForHttpsAvailabilityHandler(this IApplicationBuilder app)
             => app.UseMiddleware<CheckForHttpsAvailability>();
    }
}
