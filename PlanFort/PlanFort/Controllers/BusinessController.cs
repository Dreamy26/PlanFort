using Microsoft.AspNetCore.Mvc;
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

        public BusinessController(SeatGeekClient seatGeekClient, YelpClient yelpClient)//<< using dependency injection
        {
            _seatGeekClient = seatGeekClient;
            _yelpClient = yelpClient;
        }
      
        
     
        public IActionResult BusinessForm()
        {
            return View();
        }
        public async Task<IActionResult> BusinessFormResult(BusinessFormVM model)
        {
            var response = await _yelpClient.GetBusinessByCity(model.City, model.Category);

            var viewModel = new BusinessFormResultVM();
            var results = response.businesses;

            viewModel.Businesses = results
                .Select(results => new BusinessVM()
                { Name = results.name })
                .ToList();

            return View(viewModel);
        }


        
    }
}
