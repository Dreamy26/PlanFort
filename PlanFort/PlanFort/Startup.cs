using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using PlanFort.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanFort.Services;
using System.Net.Http.Headers;

namespace PlanFort
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

            // <--- This is finding the environment variable and pulling that into the app
            //     and giving us the connection string to the database

            services.AddDbContext<PlanFortDBContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);    // <--- Here we are using the variable to actually connect to the database
            });

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;

            }).AddEntityFrameworkStores<PlanFortDBContext>();

            services.AddHttpClient<SeatGeekClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.seatgeek.com/2");

            });
            services.AddHttpClient<YelpClient>(httpClient =>
            {
                var yelpBearer = Configuration.GetSection("Yelp:Bearer").Value; 
          
                httpClient.BaseAddress = new Uri("https://api.yelp.com/v3/");
                httpClient.DefaultRequestHeaders.Add
                ("Authorization", yelpBearer);

            });
            services.AddHttpClient<OpenWeatherClient>(httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://api.openweathermap.org/");

            });

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
