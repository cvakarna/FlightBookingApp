using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FlightBookApp.Models;
using FlightBookApp.Repository;

namespace FlightBookApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFlightBookingMgmtRepository _flightBookRepo;

        public HomeController(ILogger<HomeController> logger, IFlightBookingMgmtRepository flightBookRepo)
        {
            _logger = logger;
            this._flightBookRepo = flightBookRepo;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SearchFlight flightBookInfo)
        {
            var result = this._flightBookRepo.SearchFlightsAsync(flightBookInfo).GetAwaiter().GetResult();
            return View("SearchResults",result);
        }

        [HttpGet("search")]
        public IActionResult Search(string filterAirline)
        {
            var result = this._flightBookRepo.FilterFlights(filterAirline);
            return View("SearchResults", result);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
