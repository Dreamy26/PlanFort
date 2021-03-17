using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Models.DomainModels
{
    public class WeatherVM
    {
        public string Name { get; set; }
        public int Temp { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
