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
        //Service 
        private readonly IService _serviceCallUtil;
        //Filght Details List To Filter Data
        private List<FlightDetails> FlightDetails = new List<FlightDetails>();
        public FlightBookingMgmtRepository(IService serviceCallUtil)
        {
            this._serviceCallUtil = serviceCallUtil;
        }


        public async Task<List<FlightDetails>> SearchFlightsAsync(SearchFlight bookingInfo)
        {

            string searchDetailsJson = JsonConvert.SerializeObject(bookingInfo);
            string response = await this._serviceCallUtil.SearchFlightAsync(searchDetailsJson);
            if (!string.IsNullOrEmpty(response))
            {
                ParseResponseData(response);
            }
            return this.FlightDetails;
        }

        /// <summary>
        /// Method to Parse The Result Json and convertting into List of Models
        /// </summary>
        /// <param name="resonseData"></param>
        private void ParseResponseData(string resonseData)
        {
           JObject resonseJobj =  JObject.Parse(resonseData);
           JArray flightDetailsJArray =  resonseJobj["flightDetails"] as JArray;//Converting to JArray
           var allFlights =  flightDetailsJArray.SelectMany(obj =>
            {
                return obj["flightSegments"].ToObject<List<FlightDetails>>();
            }).ToList(); //Flattening the Result Jarray of Jarray into List<FlightDetails>
            this.FlightDetails = allFlights; 
        }


        public List<FlightDetails> FilterFlights(string airLineSearch)
        {
            List<FlightDetails> filteredResult = new List<FlightDetails>();
            if (!string.IsNullOrEmpty(airLineSearch))
            {
                filteredResult =  this.FlightDetails.Where(flightObj => flightObj.Airline.ToLower() == airLineSearch.ToLower()).ToList();
            }
            return filteredResult;
        }

    }
}
