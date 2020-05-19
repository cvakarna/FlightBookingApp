using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookApp.Models
{
    public class FlightDetails
    {

        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime OnwardDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Airline { get; set; }
        public string FlightNumber { get; set; }
        public string FlightType { get; set; }


    }
}
