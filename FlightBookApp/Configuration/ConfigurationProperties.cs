using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookApp.Configuration
{
    /// <summary>
    /// Configuration Properties
    /// </summary>
    public class ConfigurationProperties
    {
        public string LoggerLevel { get; set; }
        public string ServiceUrl { get; set; }
        public string LogFilePath { get; set; }


    }
}
