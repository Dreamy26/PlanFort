using PlanFort.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Models.ViewModels
{
    public class EventCityFormResultVM
    {
        public IEnumerable<EventVM> Events { get; set; }

        public int TripID { get; set; }
        public string DateOfTrip { get; set; }
    }
}
