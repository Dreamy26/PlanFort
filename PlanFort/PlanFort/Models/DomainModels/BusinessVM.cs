using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Models.DomainModels
{
    public class BusinessVM
    {
        public string Name { get; set; }

        public string title { get; set; }

        public string id { get; set; }

        public int yelpChildId { get; set; }

        public string address { get; set; }

        public string City { get; set; }
    }
}
