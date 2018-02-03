using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IPGTrails4Health.Data;
using IPGTrails4Health.Models;
using IPGTrails4Health.Services;
using Microsoft.Extensions.Logging; 

namespace IPGTrails4Health
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //SERVIÇO PARA AUTENTICAÇÃO
            services.AddDbContext<LoginsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringLogin")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<LoginsDbContext>()
                .AddDefaultTokenProviders();

           
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                // Lockout settings
                options.Lockout.MaxFailedAccessAttempts = 10;
                // Add other lockout settings if needed ...
                // Add other user settings if needed ...
                //options.User.RequireUniqueEmail = true;
            });

            services.AddDbContext<TurismoDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringIPGTrails4Health")));



            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

           // services.AddTransient<ITurismoRepository, EFTurismoRepository>();

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringIPGTrails4Health"))
            //);


            //services.AddTransient<ITurismoRepository, FakeProductRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.EnsurePopulated(app.ApplicationServices);
        }
    }
}
