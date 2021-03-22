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
    public class BusinessController : Controller
    {

        private readonly SeatGeekClient _seatGeekClient;
        private readonly YelpClient _yelpClient;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly PlanFortDBContext _planFortDBContext;

        public BusinessController(SeatGeekClient seatGeekClient, YelpClient yelpClient, UserManager<IdentityUser> userManager, PlanFortDBContext planFortDBContext)//<< using dependency injection
        {
            _seatGeekClient = seatGeekClient;
            _yelpClient = yelpClient;
            _userManager = userManager;
            _planFortDBContext = planFortDBContext;
        }
      
        
     
        public IActionResult BusinessForm(string city, int TripId)
        {
            var viewModel = new BusinessFormVM();

            viewModel.City = city;
            viewModel.TripID = TripId;
            return View(viewModel);
        }
        public async Task<IActionResult> BusinessFormResult(int TripID, string City, string Category)
        {
            var response = await _yelpClient.GetBusinessByCity(City, Category);

            var viewModel = new BusinessFormResultVM();
            var results = response.businesses;
            

            viewModel.Businesses = results
                .Select(results => new BusinessVM()
                { Name = results.name, title = results.categories[0].title, id = results.id, address = results.location.address1, City = results.location.city })
                .ToList();

            viewModel.TripID = TripID;
            

            return View(viewModel);
        }

        public async Task<IActionResult> AddBusiness(string id, int TripId)
        {
            var response = await _yelpClient.GetBusinessById(id);
            var businessChild = new YelpChildDAL();            
            var location = response.location;

            businessChild.ParentTripID = TripId;
            businessChild.id = response.id;
            businessChild.alias = response.alias;
            businessChild.name = response.name;
            businessChild.image_url = response.image_url;
            businessChild.is_closed = response.is_closed;
            businessChild.url = response.url;
            businessChild.review_count = response.review_count;
            businessChild.rating = response.rating;
            businessChild.price = response.price;
            businessChild.address1 = location.address1;
            businessChild.address2 = location.address2;
            businessChild.address3 = location.address3;
            businessChild.city = location.city;
            businessChild.zip_code = location.zip_code;
            businessChild.phone = response.phone;
            businessChild.display_phone = response.display_phone;
            businessChild.price = response.price;
            

            _planFortDBContext.YelpChild.Add(businessChild);
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
