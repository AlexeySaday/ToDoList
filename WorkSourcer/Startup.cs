using Microsoft.AspNetCore.Builder; 
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using System;
using WorkSourcer.AuthPer;
using WorkSourcer.Data;
using WorkSourcer.DataContext;
using WorkSourcer.Interfaces;

namespace WorkSourcer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAppData, ApplicationData>();

            services.AddMvc();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;

                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.AllowedForNewUsers = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;
            });

            services.AddControllersWithViews(opt => opt.EnableEndpointRouting = false);


        } 
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseAuthentication();
             

            app.UseMvc(endpoints =>
            {
                endpoints.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
