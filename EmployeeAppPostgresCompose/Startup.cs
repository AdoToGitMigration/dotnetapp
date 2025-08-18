using EmployeeApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace EmployeeApp
{
    /// <summary>
    /// Configures services and the application's HTTP request pipeline. This
    /// class is used by the ASP.NET runtime during startup.
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Provides access to application configuration settings, including
        /// connection strings defined in <c>appsettings.json</c>.
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services
        // to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Register MVC controllers with views.
            services.AddControllersWithViews();

            // Register the application's DbContext, specifying that PostgreSQL should
            // be used via the Npgsql provider. The connection string is read from
            // the configuration file. In production you can override this via
            // environment variables (e.g. ConnectionStrings__DefaultConnection).
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure
        // the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this
                // for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Ensure the database is created and seeded. This call will create
            // the SQLite database file if it doesn’t exist and apply any
            // pending migrations. It also seeds a few employees for demo
            // purposes if the database is empty.
            context.Database.EnsureCreated();
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee { Name = "Alice", Salary = 50000m },
                    new Employee { Name = "Bob", Salary = 60000m },
                    new Employee { Name = "Charlie", Salary = 55000m }
                );
                context.SaveChanges();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}