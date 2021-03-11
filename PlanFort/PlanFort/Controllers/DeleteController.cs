using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlanFort.Data;
using PlanFort.Models.DALModels;
using PlanFort.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlanFort.Controllers
{

    // With this controller: now a trip can be deleted 
    public class DeleteController : Controller
    {
        private readonly SeatGeekClient _seatGeekClient;
        private readonly YelpClient _yelpClient;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly PlanFortDBContext _planFortDBContext;

        public DeleteController(SeatGeekClient seatGeekClient, YelpClient yelpClient, UserManager<IdentityUser> userManager, PlanFortDBContext planFortDBContext)//<< using dependency injection
        {
            _seatGeekClient = seatGeekClient;
            _yelpClient = yelpClient;
            _userManager = userManager;
            _planFortDBContext = planFortDBContext;
        }

        // Delete trip
        public IActionResult DeleteTrip(int tripId)
        {
            TripParentDAL tripDAL = _planFortDBContext.TripParent
                .Where(trip => trip.TripID == tripId)
                .FirstOrDefault();
          
            _planFortDBContext.Remove(tripDAL);
            _planFortDBContext.SaveChanges();

            return RedirectToAction("ViewTrips", "Home");

        }
        // used naming from DALModels: int seatGeekChildId chg to lowercase
        public IActionResult DeleteEvent(int seatGeekChildId)
        {
            SeatGeekChildDAL eventDAL = _planFortDBContext.SeatGeekChild
                .Where(item => item.SeatGeekChildId == seatGeekChildId)
                .FirstOrDefault();

            _planFortDBContext.Remove(eventDAL);
            _planFortDBContext.SaveChanges();

            return RedirectToAction("ViewTrips", "Home");

        }

        // Delete a business 
        public IActionResult DeleteBusiness(int YelpChildId)
        {
            //varible names are lowercase 
            YelpChildDAL businessDAL = _planFortDBContext.YelpChild
                .Where(business => business.YelpChildId == YelpChildId)
                .FirstOrDefault();

            _planFortDBContext.Remove(businessDAL);
            _planFortDBContext.SaveChanges();

            return RedirectToAction("ViewTrips", "Home");

        }
    }
}
