using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanFort.Data;
using PlanFort.Models.DALModels;
using PlanFort.Models.DomainModels;
using PlanFort.Models.ViewModels;
using PlanFort.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Controllers
{
    public class EventController : Controller
    {
        private readonly SeatGeekClient _seatGeekClient;
        private readonly YelpClient _yelpClient;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly PlanFortDBContext _planFortDBContext;

        public EventController(SeatGeekClient seatGeekClient, YelpClient yelpClient, UserManager<IdentityUser> userManager, PlanFortDBContext planFortDBContext)//<< using dependency injection
        {
            _seatGeekClient = seatGeekClient;
            _yelpClient = yelpClient;
            _userManager = userManager;
            _planFortDBContext = planFortDBContext;
        }
        public IActionResult EventCityForm()
        {
            return View();
        }

        public async Task<IActionResult> EventCityFormResult(TripCreatorViewModel model)
        {
            var response = await _seatGeekClient.GetEventByCity(model.City);

            var viewModel = new EventCityFormResultVM();
            var results = response.events;

            viewModel.Events = results
                .Select(results => new EventVM()
                { City = results.venue.city, Title = results.title, Id = results.id})
                .ToList();

            var eventHeader = new TripParentDAL();
            eventHeader.City = model.City;
            eventHeader.UserId = _userManager.GetUserId(User);

            eventHeader.IsComplete = false;

            _planFortDBContext.TripParent.Add(eventHeader);
            _planFortDBContext.SaveChanges();

            viewModel.TripID = eventHeader.TripID;
               


            return View(viewModel);
        }
      

        public async Task<IActionResult> AddEvent(int id, int TripId )
        {
            var response = await _seatGeekClient.GetEventByID(id);
            var eventChild = new SeatGeekChildDAL();
            var performer = response.events[0].performers;
            var venue = response.events[0].venue;

            eventChild.ParentTripID = TripId;
            eventChild.performerName = performer[0].name;
            eventChild.performerType = performer[0].type;
            eventChild.city = venue.city;
            eventChild.id = id;
            eventChild.ParentTripID = TripId;
            eventChild.address = venue.address;
            eventChild.name = venue.name;
            _planFortDBContext.SeatGeekChild.Add(eventChild);
            _planFortDBContext.SaveChanges();
            return RedirectToAction("ViewTrips", "Home");
        }
    }
}
