using FlightBookApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookApp.Repository
{
    public class FlightBookingMgmtRepository:IFlightBookingMgmtRepository
    {

        private readonly IService _serviceCallUtil;
        private List<FlightDetails> FlightDetails = new List<FlightDetails>();
        public FlightBookingMgmtRepository(IService serviceCallUtil)
        {
            this._serviceCallUtil = serviceCallUtil;
        }


        public async Task<List<FlightDetails>> BookFlightAsync(BookFlight bookingInfo)
        {

            string bookingDetailsJson = JsonConvert.SerializeObject(bookingInfo);
            string response = await this._serviceCallUtil.BookFlightAsync(bookingDetailsJson);
            if (!string.IsNullOrEmpty(response))
            {
                ParseResponseData(response);
            }
            return this.FlightDetails;
        }

        private void ParseResponseData(string resonseData)
        {
           JObject resonseJobj =  JObject.Parse(resonseData);
           JArray flightDetailsJArray =  resonseJobj["flightDetails"] as JArray;
           var allFlights =  flightDetailsJArray.SelectMany(obj =>
            {
                return obj["flightSegments"].ToObject<List<FlightDetails>>();
            }).ToList();
            this.FlightDetails = allFlights;
        }


    }
}
