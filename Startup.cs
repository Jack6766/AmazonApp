using AmazonApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AmazonApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AmazonDbContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:AmazonBookConnection"]);

           });

            services.AddScoped<IAmazonRepository, EFAmazonRepository>();

            //This method allows us to use the razor pages in the app
            services.AddRazorPages();

            //These will get the info in the session to stick
            services.AddDistributedMemoryCache();
            services.AddSession();

            //The AddScoped method specifies that the same object should be used to satisfy related requests for Cart instances.
            //How requests are related can be configured, but by default, it means that any Cart required by components handling
            //the same HTTP request will receive the same object. Rather than provide the AddScoped method with a type mapping, as
            //I did for the repository, I have specified a lambda expression that will be invoked to satisfy Cart requests. The expression
            //receives the collection of services that have been registered and passes the collection to the GetCart method of the
            //SessionCart class. The result is that requests for the Cart service will be handled by creating SessionCart objects,
            //which will serialize themselves as session data when they are modified.
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

            //I also added a service using the AddSingleton method, which specifies that the same object should always be used.
            //The service I created tells ASP.NET Core to use the HttpContextAccessor class when implementations of the IHttpContextAccessor
            //interface are required.This service is required so I can access the current session in the SessionCart class.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //This will set up a session for the user which will keep the stuff in the cart as long as we keep it loaded.
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute(
                    "pagination",
                    "/P{pageNum}",
                    new { Controller = "Home", action = "Index" });
                
                endpoints.MapDefaultControllerRoute();

                //This will let Razor Pages act as an endpoint
                endpoints.MapRazorPages();
        });

            SeedData.EnsurePopulated(app);
        }
    }
}
