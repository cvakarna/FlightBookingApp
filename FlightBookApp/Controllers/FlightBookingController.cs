using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookApp.Models;
using FlightBookApp.Repository;
using Microsoft.AspNetCore.Mvc;


namespace FlightBookApp.Controllers
{
    public class FlightBookingController : Controller
    {
        private readonly IFlightBookingMgmtRepository _flightBookRepo;
        public FlightBookingController(IFlightBookingMgmtRepository flightBookRepo)
        {
            this._flightBookRepo = flightBookRepo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> BookFlight([FromBody]BookFlight flightBookInfo)
        {
            await this._flightBookRepo.BookFlightAsync(flightBookInfo);
            return null;
        }

    }
}
