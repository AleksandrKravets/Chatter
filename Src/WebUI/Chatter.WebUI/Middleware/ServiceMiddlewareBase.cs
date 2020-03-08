using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Chatter.WebUI.Middleware
{
    public abstract class ServiceMiddlewareBase
    {
        public static readonly JsonSerializerSettings JsonSerializerSettings = 
            new JsonSerializerSettings
            { 
                ContractResolver = new DefaultContractResolver 
                { 
                    NamingStrategy = new CamelCaseNamingStrategy() 
                } 
            };

        protected RequestDelegate next;

        public ServiceMiddlewareBase(RequestDelegate next)
        {
            this.next = next;
        }

        protected Task OkResult(HttpContext context, object result = null) => Json(context, result, StatusCodes.Status200OK);

        protected Task BadRequest(HttpContext context, object result = null) => Json(context, result, StatusCodes.Status400BadRequest);

        protected Task Unauthorized(HttpContext context, string message) => Json(context, message, StatusCodes.Status401Unauthorized);

        protected Task ObjectResult(HttpContext context, object result, int statusCode) => Json(context, result, statusCode);

        protected Task Json(HttpContext context, object result, int statusCode = StatusCodes.Status200OK)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            string serializedContent = JsonConvert.SerializeObject(result, JsonSerializerSettings);
            byte[] data = Encoding.UTF8.GetBytes(serializedContent);
            return context.Response.Body.WriteAsync(data, 0, data.Length);
        }
    }
}
