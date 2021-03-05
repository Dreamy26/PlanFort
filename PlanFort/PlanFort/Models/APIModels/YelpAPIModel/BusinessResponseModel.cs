using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Models.YelpAPIModel
{
    public class BusinessResponseModel
    {

        public Business[] businesses { get; set; }
        public int total { get; set; }
        public Region region { get; set; }
    }    

    public class Region
    {
        public Center center { get; set; }
    }

    public class Center
    {
        public float longitude { get; set; }
        public float latitude { get; set; }
    }

    public class Business
    {
        public string id { get; set; }
        public string alias { get; set; }
        public string name { get; set; }
        public string image_url { get; set; }
        public bool is_closed { get; set; }
        public string url { get; set; }
        public int review_count { get; set; }
        public Category[] categories { get; set; }
        public float rating { get; set; }
        public Coordinates coordinates { get; set; }
        public string[] transactions { get; set; }
        public string price { get; set; }
        public Location location { get; set; }
        public string phone { get; set; }
        public string display_phone { get; set; }
        public float distance { get; set; }
    }

    public class Coordinates
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
    }

    public class Location
    {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string city { get; set; }
        public string zip_code { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string[] display_address { get; set; }
    }

    public class Category
    {
        public string alias { get; set; } 
        public string title { get; set; }
    }

    
}
