using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public HomeController(ILogger<HomeController> logger, SeatGeekClient seatGeekClient)
        {
            _logger = logger;
            _seatGeekClient = seatGeekClient;
        }

        public async Task<IActionResult> Index()
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
    }
}
