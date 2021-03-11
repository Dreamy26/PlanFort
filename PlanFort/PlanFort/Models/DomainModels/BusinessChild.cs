using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Models.DomainModels
{
    public class BusinessChild
    {
        public string id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public int ParentTripId { get; set; }
        public int YelpChildId { get; set; }

    }
}
