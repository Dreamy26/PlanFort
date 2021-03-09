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
        public HomeController(ILogger<HomeController> logger, SeatGeekClient seatGeekClient, UserManager<IdentityUser> userManager, PlanFortDBContext planFortDBContext)
        {
            _logger = logger;
            _seatGeekClient = seatGeekClient;
            _userManager = userManager;
            _planFortDBContext = planFortDBContext;
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
        public IActionResult ViewTrips()
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
                .Select(trip => new TripHeader() { City = trip.City, TripID = trip.TripID })
                .ToList();

            viewModel.Businesses = yelpChildren
               .Select(business => new BusinessChild() { address1 = business.address1, address2 = business.address2, address3 = business.address3, name = business.name, phoneNumber = business.phone, ParentTripId = business.ParentTripID})
               .ToList();

            viewModel.Events = seatGeekChildren
               .Select(item => new EventChild() { name = item.name, address = item.address, city = item.city, performerName = item.performerName, performerType = item.performerType, id = item.id, ParentTripId = item.ParentTripID })
               .ToList();

            return View(viewModel);
        }
            
    }
}
