using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Models.DomainModels
{
    public class EventChild
    {
        public int id { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string performerType { get; set; }
        public string performerName { get; set; }
        public string name { get; set; }
        public int ParentTripId { get; set; }
        public int SeatGeekChildId { get; set; }
    }
}
