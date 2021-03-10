using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanFort.Data;
using PlanFort.Models.DALModels;
using PlanFort.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Controllers
{
    public class UpdateController : Controller
    {
        private readonly SeatGeekClient _seatGeekClient;
        private readonly YelpClient _yelpClient;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly PlanFortDBContext _planFortDBContext;

        public UpdateController(SeatGeekClient seatGeekClient, YelpClient yelpClient, UserManager<IdentityUser> userManager, PlanFortDBContext planFortDBContext)//<< using dependency injection
        {
            _seatGeekClient = seatGeekClient;
            _yelpClient = yelpClient;
            _userManager = userManager;
            _planFortDBContext = planFortDBContext;
        }
        public IActionResult MarkTripComplete(int tripId)
        {
            TripParentDAL tripDAL = _planFortDBContext.TripParent
                .Where(trip => trip.TripID == tripId)
                .FirstOrDefault();
            tripDAL.IsComplete = true;
            _planFortDBContext.Update(tripDAL);
            _planFortDBContext.SaveChanges();

            return RedirectToAction("ViewTrips", "Home");

        }
    }
}
