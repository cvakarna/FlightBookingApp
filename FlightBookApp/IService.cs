using FlightBookApp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookApp
{
    /// <summary>
    /// Interface Which Define to consume the rest based external services
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Method to Post Details and Consume the Result
        /// </summary>
        /// <param name="bookingInfo"></param>
        /// <returns>Resut Data from The service</returns>
        Task<string> SearchFlightAsync(string bookingInfo);

    }
}
