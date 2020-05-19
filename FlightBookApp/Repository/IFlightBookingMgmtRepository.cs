using FlightBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookApp.Repository
{
    /// <summary>
    /// Interface Which defines the Flight Serach  Details 
    /// </summary>
    public interface IFlightBookingMgmtRepository
    {
        /// <summary>
        /// Method To Fetch The Available Flight Details 
        /// </summary>
        /// <param name="bookingInfo"></param>
        /// <returns>returns the List of avaliable flights</returns>
        Task<List<FlightDetails>> SearchFlightsAsync(SearchFlight bookingInfo);

        /// <summary>
        /// Method To Filter On The avlaible flights 
        /// </summary>
        /// <param name="filterAirLine"></param>
        /// <returns>fitered List Of flights</returns>
        List<FlightDetails>  FilterFlights(string filterAirLine);
    }
}
