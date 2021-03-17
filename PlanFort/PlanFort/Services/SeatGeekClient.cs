using Microsoft.Extensions.Configuration;
using PlanFort.Models.SeatGeekAPIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlanFort.Services
{
    public class SeatGeekClient
    {
        private readonly HttpClient _client;

        public SeatGeekClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        public async Task<EventsResponseModel> GetAllEvents()
        {
            var clientID = Configuration.GetSection("SeatGeek:ClientID").Value;

            return await GetAsync<EventsResponseModel>
                ($"/events?client_id={clientID}");
        }
        public async Task<EventsResponseModel> GetEventByCity(string city, string dateOfTrip, string nextDay)
        {
            var clientID = Configuration.GetSection("SeatGeek:ClientID").Value;

            return await GetAsync<EventsResponseModel>
                ($"/events?venue.city={city}&datetime_utc.gte={dateOfTrip}&datetime_utc.lte={nextDay}&client_id={clientID}");

            //Calling SeatGeek API and searching events for certain cities
        }

        public async Task<EventsResponseModel> GetEventByID(int id )
        {
            return await GetAsync<EventsResponseModel>
                ($"/events/?id={id}&client_id=MjE1NjY1OTZ8MTYxNDY1MTAwMC41MDk3Mjk2");

            //Calling SeatGeek API and searching events for certain cities
        }


        private async Task<T> GetAsync<T>(string endPoint)
        {
            var response = await _client.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                // var jsonOptions = new JsonSerializerOptions();

                var model = await JsonSerializer.DeserializeAsync<T>(content);

                return model;
            }
            else
            {
                throw new HttpRequestException("SeatGeek API returned bad response");
            }
        }

        internal Task GetEventID(int id)
        {
            throw new NotImplementedException();
        }
    }   
}
