using Chatter.Domain.Entities;
using Chatter.Infrastructure.Contexts;
using Chatter.WebUI.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddDbContext<ApplicationDbContext>(opts => {
                opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //services.AddIdentity<User, IdentityRole>(opts => {
            //    opts.Password.RequireDigit = false;
            //    opts.Password.RequireLowercase = false;
            //    opts.Password.RequireNonAlphanumeric = false;
            //    opts.Password.RequireUppercase = false;
            //})
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddControllersWithViews();

            services.AddSignalR();

            services.AddCors(options => 
            {
                options.AddPolicy("AllowAny", x => {
                    x.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                        //.WithOrigins("http://localhost:4200");
                });
            });

            //services.AddSpaStaticFiles(configuration => {
            //    configuration.RootPath = "ClientApp/dist";
            //});
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //if (!env.IsDevelopment())
            //{
            //    app.UseSpaStaticFiles();
            //}

            app.UseCors("AllowAny");

            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            //app.UseSpa(spa => {
            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});
        }
    }
}
