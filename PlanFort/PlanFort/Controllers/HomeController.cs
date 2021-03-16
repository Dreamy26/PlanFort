using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanFort.Data;
using PlanFort.Models;
using PlanFort.Models.DomainModels;
using PlanFort.Models.ViewModels;
using PlanFort.Services;

namespace PlanFort.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SeatGeekClient _seatGeekClient;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly PlanFortDBContext _planFortDBContext;
        private readonly OpenWeatherClient _openWeatherClient;

        public HomeController(OpenWeatherClient openWeatherClient, ILogger<HomeController> logger, SeatGeekClient seatGeekClient, UserManager<IdentityUser> userManager, PlanFortDBContext planFortDBContext)
        {
            _logger = logger;
            _seatGeekClient = seatGeekClient;
            _userManager = userManager;
            _planFortDBContext = planFortDBContext;
            _openWeatherClient = openWeatherClient;
        }

        public IActionResult Index()
        {
            return View();
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


        public IActionResult TripCreator()

        {
            return View();

        }

        [Authorize]
        public async Task<IActionResult> ViewTrips()
        {
            var userID = _userManager.GetUserId(User);
            var eventHeaders = _planFortDBContext.TripParent
                .Where(eventItem => eventItem.UserId == userID)
                .ToList();


            var yelpChildren = _planFortDBContext.YelpChild
            .Where(eventItem => eventItem.Trip.UserId == userID)
            .ToList();


            var seatGeekChildren = _planFortDBContext.SeatGeekChild
            .Where(eventItem => eventItem.Trip.UserId == userID)
            .ToList();

            var viewModel = new ViewTripsViewModel();
            viewModel.Trips = eventHeaders
                .Select(trip => new TripHeader() { City = trip.City, TripID = trip.TripID, IsComplete = trip.IsComplete })
                .ToList();

            viewModel.Businesses = yelpChildren
               .Select(business => new BusinessChild() { address1 = business.address1, address2 = business.address2, address3 = business.address3, name = business.name, phoneNumber = business.phone, ParentTripId = business.ParentTripID, YelpChildId = business.YelpChildId })
               .ToList();

            viewModel.Events = seatGeekChildren
               .Select(item => new EventChild() { name = item.name, address = item.address, city = item.city, performerName = item.performerName, performerType = item.performerType, id = item.id, ParentTripId = item.ParentTripID, SeatGeekChildId = item.SeatGeekChildId })
               .ToList();

            viewModel.Weather = new List<WeatherVM>();

            foreach (var trip in viewModel.Trips)
            {
                var response = await _openWeatherClient.GetWeather(trip.City);
                var weather = new WeatherVM();
                weather.Description = response.weather[0].description;
                weather.Icon = response.weather[0].icon;
                weather.Temp = response.main.temp;

                weather.Name = response.name;
                viewModel.Weather.Add(weather);
            }

            return View(viewModel);
        }

    }

}

