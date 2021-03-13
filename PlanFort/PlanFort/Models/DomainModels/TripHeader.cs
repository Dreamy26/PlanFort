using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Models.DomainModels
{
    public class TripHeader
    {
        public int TripID { get; set; }
        public string City { get; set; }
        public bool IsComplete { get; set; }

        public string DateOfTrip { get; set; }


    }
}
