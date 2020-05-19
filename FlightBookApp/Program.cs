using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookApp.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FlightBookApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigurationUtil.InitializeProperties();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
