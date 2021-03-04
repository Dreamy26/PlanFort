using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanFort.Models.SeatGeekAPIModel
{
    public class EventsResponseModel
    {
        public Event[] events { get; set; }
        public Meta meta { get; set; }
        public In_Hand in_hand { get; set; }
    }   

    public class Meta
    {
        public int total { get; set; }
        public int took { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public object geolocation { get; set; }
    }

    public class In_Hand
    {
    }

    public class Event
    {
        public string type { get; set; }
        public int id { get; set; }
        public DateTime datetime_utc { get; set; }
        public Venue venue { get; set; }
        public bool datetime_tbd { get; set; }
        public Performer[] performers { get; set; }
        public bool is_open { get; set; }
        public object[] links { get; set; }
        public DateTime datetime_local { get; set; }
        public bool time_tbd { get; set; }
        public string short_title { get; set; }
        public DateTime visible_until_utc { get; set; }
        public Stats stats { get; set; }
        public Taxonomy1[] taxonomies { get; set; }
        public string url { get; set; }
        public float score { get; set; }
        public DateTime announce_date { get; set; }
        public DateTime created_at { get; set; }
        public bool date_tbd { get; set; }
        public string title { get; set; }
        public float popularity { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public Access_Method1 access_method { get; set; }
        public object event_promotion { get; set; }
        public Announcements announcements { get; set; }
        public bool conditional { get; set; }
        public object enddatetime_utc { get; set; }
        public object[] themes { get; set; }
        public object[] domain_information { get; set; }
    }

    public class Venue
    {
        public string state { get; set; }
        public string name_v2 { get; set; }
        public string postal_code { get; set; }
        public string name { get; set; }
        public object[] links { get; set; }
        public string timezone { get; set; }
        public string url { get; set; }
        public float score { get; set; }
        public Location location { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public bool has_upcoming_events { get; set; }
        public int num_upcoming_events { get; set; }
        public string city { get; set; }
        public string slug { get; set; }
        public string extended_address { get; set; }
        public int id { get; set; }
        public int popularity { get; set; }
        public Access_Method access_method { get; set; }
        public int metro_code { get; set; }
        public int capacity { get; set; }
        public string display_location { get; set; }
    }

    public class Location
    {
        public float lat { get; set; }
        public float lon { get; set; }
    }

    public class Access_Method
    {
        public string method { get; set; }
        public DateTime created_at { get; set; }
        public bool employee_only { get; set; }
    }

    public class Stats
    {
        public int? listing_count { get; set; }
        public int? average_price { get; set; }
        public int? lowest_price_good_deals { get; set; }
        public int? lowest_price { get; set; }
        public int? highest_price { get; set; }
        public int? visible_listing_count { get; set; }
        public int[] dq_bucket_counts { get; set; }
        public int? median_price { get; set; }
        public int? lowest_sg_base_price { get; set; }
        public int? lowest_sg_base_price_good_deals { get; set; }
    }

    public class Access_Method1
    {
        public string method { get; set; }
        public DateTime created_at { get; set; }
        public bool employee_only { get; set; }
    }

    public class Announcements
    {
        public Checkout_Disclosures checkout_disclosures { get; set; }
    }

    public class Checkout_Disclosures
    {
        public Message[] messages { get; set; }
    }

    public class Message
    {
        public string text { get; set; }
    }

    public class Performer
    {
        public string type { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int id { get; set; }
        public Images images { get; set; }
        public Division[] divisions { get; set; }
        public bool has_upcoming_events { get; set; }
        public bool primary { get; set; }
        public Stats1 stats { get; set; }
        public Taxonomy[] taxonomies { get; set; }
        public string image_attribution { get; set; }
        public string url { get; set; }
        public float score { get; set; }
        public string slug { get; set; }
        public int? home_venue_id { get; set; }
        public string short_name { get; set; }
        public int num_upcoming_events { get; set; }
        public Colors colors { get; set; }
        public string image_license { get; set; }
        public int popularity { get; set; }
        public bool home_team { get; set; }
        public Location1 location { get; set; }
        public bool away_team { get; set; }
    }

    public class Images
    {
        public string huge { get; set; }
    }

    public class Stats1
    {
        public int event_count { get; set; }
    }

    public class Colors
    {
        public string[] all { get; set; }
        public string iconic { get; set; }
        public string[] primary { get; set; }
    }

    public class Location1
    {
        public float lat { get; set; }
        public float lon { get; set; }
    }

    public class Division
    {
        public int taxonomy_id { get; set; }
        public string short_name { get; set; }
        public string display_name { get; set; }
        public string display_type { get; set; }
        public int division_level { get; set; }
        public string slug { get; set; }
    }

    public class Taxonomy
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? parent_id { get; set; }
        public Document_Source document_source { get; set; }
        public int rank { get; set; }
    }

    public class Document_Source
    {
        public string source_type { get; set; }
        public string generation_type { get; set; }
    }

    public class Taxonomy1
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? parent_id { get; set; }
        public int rank { get; set; }
    }

    
}
