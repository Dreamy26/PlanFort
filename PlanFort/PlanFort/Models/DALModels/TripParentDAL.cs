using Microsoft.AspNetCore.Identity;
using PlanFort.Models.YelpAPIModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Models.DALModels
{
    public class TripParentDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TripID { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public string City { get; set; }

        public IEnumerable<YelpChildDAL> YelpChildren { get; set; }

        public IEnumerable<SeatGeekChildDAL> SeatGeekChildren { get; set; }
        public bool IsComplete { get; set; }
        public string DateOfTrip { get; set; }

    }


}
