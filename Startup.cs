using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MyMusicStoreTutorial.Models;
using Microsoft.Extensions.Configuration;
using IdentityServer4.Stores;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Services;
using IdentityServer4.AspNetIdentity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MyMusicStoreTutorial
{
    //class MyClass : RoleManager
    //{

    //}
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private async void HardCodedAdmin(IServiceProvider serviceProvider)
        {
            try
            {
                var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                bool adminRoleExists = await RoleManager.RoleExistsAsync("Admin");

                if (!adminRoleExists)
                {
                    await RoleManager.CreateAsync(new IdentityRole("Admin"));
                }

                var Admin = new ApplicationUser { UserName = "szymon_0@hotmail.com", Email = "Input.Email" };
                var AddAdminRoleResult = await UserManager.CreateAsync(Admin, "7W-*6btcPaafc_@");

                if (AddAdminRoleResult.Succeeded)
                {
                    var AddAdminResult = await UserManager.AddToRoleAsync(Admin, "Admin");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("B³¹d w dodawaniu ról\n" + e.Message);

            }

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MusicStoreEntities>();


            services.AddDbContext<IdentityDatabaseContext>(options =>
         options.UseInMemoryDatabase("InMemoryDb"));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                        options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<IdentityDatabaseContext>()
                .AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/LogOn";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

#if DEBUG
            services.AddDirectoryBrowser();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            HardCodedAdmin(services);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
#if DEBUG
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, " ")),
                RequestPath = "/all"
            });
#endif
               
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "Content")),
                RequestPath = "/Content"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "Scripts")),
                RequestPath = "/Scripts"
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
