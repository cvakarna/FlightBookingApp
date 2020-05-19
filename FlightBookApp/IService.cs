using FlightBookApp.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookApp
{
    public interface IService
    {
        Task<string> BookFlightAsync(string bookingInfo);

    }
}
