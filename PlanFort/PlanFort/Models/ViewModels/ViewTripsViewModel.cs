using PlanFort.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Models.ViewModels
{
    public class ViewTripsViewModel
    {
    
        public List<TripHeader> Trips { get; set; }
        public List<EventChild> Events { get; set; }
        public List<BusinessChild> Businesses { get; set; }
        public List<WeatherVM> Weather { get; set; }
    }
}
