using Chatter.WebUI.Infrastructure.ConfigurationModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Chatter.WebUI.Middleware
{
    public class CheckForHttpsAvailability : ServiceMiddlewareBase
    {
        private readonly IOptions<RequestOptions> _requestOptions;

        public CheckForHttpsAvailability(RequestDelegate next, IOptions<RequestOptions> requestOptions)
            : base(next)
        {
            this._requestOptions = requestOptions;
        }

        public async Task Invoke(HttpContext context)
        {
            if (_requestOptions.Value.IsHttpsRequired && !context.Request.IsHttps)
            {
                var result = new { message = "Https required" };
                await ObjectResult(context, result, 500);
            } else
            {
                await next(context);
            }
        }
    }
}
