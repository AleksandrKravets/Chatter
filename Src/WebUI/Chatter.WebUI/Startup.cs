using Chatter.Application;
using Chatter.Infrastructure;
using Chatter.WebUI.Factories.Contracts;
using Chatter.WebUI.Factories.Implementations;
using Chatter.WebUI.Hubs;
using Chatter.WebUI.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace Chatter.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();

            services.AddInfrastructure();

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddSignalR();

            services.AddSingleton<ITokenFactory, TokenFactory>();

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(tokenOpt => {
                    tokenOpt.RequireHttpsMetadata = false; // SSL �� ������������
                    tokenOpt.TokenValidationParameters = new JwtAuthParameters(Constants.Secret);

                    tokenOpt.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddCors(options => options.AddPolicy("AllowAllOrigin",
                                                 builder => builder.AllowAnyHeader()
                                                                   .AllowAnyMethod()
                                                                   .AllowAnyOrigin()
                                                                   /*.WithOrigins("http://localhost:4200")*/));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigin");

            app.UseRouting();

            // app.UseAuthentication();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
