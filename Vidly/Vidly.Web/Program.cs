using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using System;

namespace Vidly.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isDev = string.Equals(environment, "development", StringComparison.InvariantCultureIgnoreCase);
            var configFileName = isDev ? "nlog.Development.config" : "nlog.config";

            var logger = NLogBuilder.ConfigureNLog(configFileName).GetCurrentClassLogger();

            logger.Info("Starting application. {Environment}, {LoggingConfigurationFileName}", environment, configFileName);

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                logger.Error(e, "Failed to start application", e);
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
