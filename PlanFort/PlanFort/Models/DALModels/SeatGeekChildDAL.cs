using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanFort.Models.DALModels
{
    public class SeatGeekChildDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatGeekChildId { get; set; }

        [ForeignKey("Trip")]       // "ParentTripID" is actual field name in SeatGeekChild table, line 32 and 34 tell the system where to find the reference
        public int ParentTripID { get; set; }
        public TripParentDAL Trip { get; set; }
      
        public int id { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string performerType { get; set; }
        public string performerName { get; set; }
        public string name { get; set; }
    }


}
