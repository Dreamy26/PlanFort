using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Models.ViewModels
{
    public class EventCityFormVM
    {
        public string City { get; set; }

        public int TripID { get; set; }

        public DateTime DateOfTrip { get; set; }
    }
}
