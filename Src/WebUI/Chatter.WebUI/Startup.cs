using Chatter.Application;
using Chatter.Infrastructure;
using Chatter.WebUI.Extensions;
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
using System;
using System.IO;
using System.Reflection;

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

            services.AddControllersWithViews()
                .AddNewtonsoftJson();

            services.AddSignalR();

            services.ConfigureSetting<RequestOptions>(Configuration);

            //string secretKey = KeyGenerator.GenerateKey();

            services.AddSingleton<ITokenFactory, TokenFactory>(c => new TokenFactory(Constants.Secret));

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(tokenOpt => {
                    tokenOpt.RequireHttpsMetadata = false; // SSL не используется
                    tokenOpt.TokenValidationParameters = new JwtAuthParameters(Constants.Secret);
                });

            services.AddSwaggerGen(c => {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.DescribeAllParametersInCamelCase();
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Chatter", Version = "v1", Description = "Chatter API", });
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

            //app.UseSwagger();

            //app.UseSwaggerUI(c => {
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chatter API V1");
            //    c.DisplayRequestDuration();
            //    c.EnableDeepLinking();
            //    c.DefaultModelExpandDepth(10);
            //    c.DefaultModelsExpandDepth(-2);
            //    c.DisplayOperationId();
            //    c.EnableFilter();
            //    c.MaxDisplayedTags(100);
            //    c.ShowExtensions();
            //    c.EnableValidator();
            //});

            app.UseCheckForHttpsAvailabilityHandler();
            app.UseCors("AllowAllOrigin");
            //app.UseCustomExceptionHandler();
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
