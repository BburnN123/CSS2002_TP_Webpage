using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using wms_inventory.Models;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

namespace wms_inventory
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Instead of creating a new instance, use AppDbContext
            // Performance is better
            // It keeps multiple DbContext objects alive and gives you an unused one rather than creating a new one each time.
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            // A new instance is provided to every controller and every service.
            // Provide which repository you want to use Mock or SQL
            // SQL => AddScoped
            services.AddScoped<ITrackingRepository, MockTrackingRepository>();
            services.AddScoped<ITaskListRepository, MockTasklistRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();

            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
