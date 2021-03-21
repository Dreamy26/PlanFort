using PlanFort.Models.APIModels.YelpAPIModel;
using PlanFort.Models.YelpAPIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlanFort.Services
{
    public class YelpClient
    {
        private readonly HttpClient _yelpClient;

        public YelpClient(HttpClient yelpClient)
        {
            _yelpClient = yelpClient;
        }
        public async Task<BusinessResponseModel> GetBusinessByCity(string city, string businessType)
        {
            return await GetAsync<BusinessResponseModel>
                ($"businesses/search?location={city}&categories={businessType}&limit=50");
        }
        public async Task<BusinessResponseModel> GetBusinessByCity(string city)
        {
            return await GetAsync<BusinessResponseModel>
                ($"businesses/search?location={city}");
        }

        public async Task<SingleBusinessModel> GetBusinessById(string id)
        {
            return await GetAsync<SingleBusinessModel>
                ($"businesses/{id}");
        }

        private async Task<T> GetAsync<T>(string endPoint)
        {
            var response = await _yelpClient.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                // var jsonOptions = new JsonSerializerOptions();

                var model = await JsonSerializer.DeserializeAsync<T>(content);

                return model;
            }
            else
            {
                throw new HttpRequestException("Yelp API return Bad Response");
            }
        }
    }
}
