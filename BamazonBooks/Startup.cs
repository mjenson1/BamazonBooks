using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BamazonBooks.Models;

namespace BamazonBooks
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //constructor receives an IConfiguration object through its constructor and assigns it to the Configuration property, which is used to access the connection string
        {
            Configuration = configuration; //holds connection strings, and configurations to get us started
        }

        //The IConfiguration interface provides access to the ASP.NET Core configuration system, which includes the contents of the appsettings.json file
        public IConfiguration Configuration { get; set; } // add a set
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) //used to set up objects, known as services that can be used throughout the app
        {
            services.AddControllersWithViews(); //sets up the shared objects required by applications using the MVC Framework and the Razor view engine.

            services.AddDbContext<BamazonDbContext>(options =>  //registers the database context calss and configures the relationship with the database
           {
               options.UseSqlite(Configuration["ConnectionStrings:BamazonBooksConnection"]); //set up a service that connects to a general connection string, modify a configuration file. string is read via the IConfiguration object
           });

            services.AddScoped<IBooksRepository, EFBooksRepository>(); //creates a service where HTTP request gets its own repository object, which is the way that Entity Framework Core is typically used

            services.AddRazorPages(); //a service we have to add in for Razor Pages

            services.AddDistributedMemoryCache();

            services.AddSession(); //allow us to keep things in cart as part of our session
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp)); //The AddScoped method specifies that the same object should be used to satisfy related requests for Cart instances. How requests are related can be configured, but by default, it means that any Cart required by components handling the same HTTP request will receive the same object.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //specifies that the same object should always be used. The service I created tells ASP.NET Core to use the HttpContextAccessor class when implementations of the IHttpContextAccessor interface are required. This service is required so I can access the current session in the SessionCart class.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. Populated with middleware components
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //displays details of exceptions that occur in the app, useful for development
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(); //enables support for serving static content from wwwroot folder

            app.UseSession();

            app.UseRouting(); //provides the endpoint routing feature which matches HTTP request to the app features - known as endpoints - which produce a response for them

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //what if they type in category and page
                endpoints.MapControllerRoute("catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });
                
                endpoints.MapControllerRoute("pagination",
                    "Books/{pageNum}", //changes the way the route looks
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute(); //tells ASP.NET Core how to match URLs to controller classes. 
                //the config applied by this method declares that the Index action method defined by the Home controller will be used to handle requests

                endpoints.MapRazorPages(); // add this as well. Registers Razor Pages as endpoints that hte URL routing system can use to handle requests
            });

            SeedData.EnsurePopulated(app); //can remove this once database has been created. Used to seed the database when the application starts.
        }
    }
}
