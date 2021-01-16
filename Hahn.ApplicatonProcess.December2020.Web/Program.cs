using Hahn.ApplicatonProcess.December2020.Data.Entities;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region for in momory database
            //1. Get the IWebHost which will host this application.
            var host = CreateWebHostBuilder(args).Build();

            //2. Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                //3. Get the instance of BoardGamesDBContext in our services layer
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationContext>();

                //4. Call the DataGenerator to create sample data
                DataGenerator.Initialize(services);
            }

            //Continue to run the application
            host.Run();
            #endregion
            //used for logging
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// For Logging
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configSettings = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()

                .WriteTo.File(configSettings["Logging:LogPath"], rollOnFileSizeLimit: true, fileSizeLimitBytes: 100000)
                .CreateLogger();

            return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(config =>
            {
                config.AddConfiguration(configSettings);
            })
            .ConfigureLogging(logging =>
            {
                logging.AddSerilog();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

        }

        /// <summary>
        /// //for In memory DataBase
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                 .UseStartup<Startup>();
    }
}
