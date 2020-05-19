using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookApp.Configuration
{
    public static class ConfigurationUtil
    {
        public static ConfigurationProperties Properties;

        public static void InitializeProperties()
        {
            Properties = new ConfigurationProperties();
            try
            {
                var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environmentName ?? "Production"}.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                configuration.GetSection(environmentName).Bind(Properties);

                string filePath = "C:\\log\\flightbook_app.log";
                if (!string.IsNullOrEmpty(Properties.LogFilePath))
                {
                    filePath = Properties.LogFilePath;
                }

               
            }
            catch (Exception ex)
            {
               
            }

        }

    }
}
