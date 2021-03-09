using PlanFort.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Models.ViewModels
{
    public class BusinessFormResultVM
    {
        public IEnumerable<BusinessVM> Businesses { get; set; }

        public int TripID { get; set; }
       
    }
}
