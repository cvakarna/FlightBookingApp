using FlightBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookApp.Repository
{
    public interface IFlightBookingMgmtRepository
    {
        Task<List<FlightDetails>> BookFlightAsync(BookFlight bookingInfo);
    }
}
