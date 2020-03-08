using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Chatter.WebUI.Middleware
{
    public class ExceptionHandlingMiddleware : ServiceMiddlewareBase
    {
        public ExceptionHandlingMiddleware(RequestDelegate next)
            : base(next)
        {
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            } 
            catch (TimeoutException)
            {
                await ObjectResult(context, new { error = "TimeoutException" }, StatusCodes.Status504GatewayTimeout);
            } 
            catch (Exception)
            {
                await ObjectResult(context, new { error = "Exception" }, StatusCodes.Status500InternalServerError);
            }
        }

    }
}
