using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EmployeeApp
{
    /// <summary>
    /// The main entry point for the application. This class bootstraps the
    /// ASP.NET Core host and wires up the Startup class. When the application
    /// starts, it creates and configures the web host and then runs it.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates an instance of <see cref="IHostBuilder"/> configured to use
        /// default settings and the <see cref="Startup"/> class. This method is
        /// separated to enable easier testing and configuration.
        /// </summary>
        /// <param name="args">Command‑line arguments passed to the application.</param>
        /// <returns>A configured host builder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}