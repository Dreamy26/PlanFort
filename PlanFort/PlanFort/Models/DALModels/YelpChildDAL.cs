using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanFort.Models.DALModels
{
    public class YelpChildDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YelpChildId { get; set; }

        [ForeignKey("Trip")]       // "ParentTripID" is actual field name in YelpChild table, line 32 and 34 tell the system where to find the reference
        public int ParentTripID { get; set; }
        public TripParentDAL Trip { get; set; }

        public string id { get; set; }
        public string alias { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
        public bool is_closed { get; set; }
        public string url { get; set; }
        public int review_count { get; set; }
        public float rating { get; set; }        
        public string price { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string city { get; set; }
        public string zip_code { get; set; }
        public string phone { get; set; }
        public string display_phone { get; set; }

    }


}
