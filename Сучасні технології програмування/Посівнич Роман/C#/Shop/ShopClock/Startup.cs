using ShopClock.Data;
using ShopClock.Data.Interfaces;
using ShopClock.Data.Mocks;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.EntityFrameworkCore;
using ShopClock.Data.Repository;
using System.Net.Mime;
using ShopClock.Data.Models;

namespace ShopClock
{
    public class Startup
    {

        private IConfigurationRoot _confstring;

        public Startup(IHostingEnvironment hostEnv)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContent>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllClocks, ClockRepository>();
            services.AddTransient<IClockCategory, CategoryRepository>();
			services.AddTransient<IAllOrders, OrdersRepository>();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting(); 

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "categoryFilter",
                    pattern: "Clock/{action}/{category?}",
                    defaults: new { controller = "Clock", action = "List" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
