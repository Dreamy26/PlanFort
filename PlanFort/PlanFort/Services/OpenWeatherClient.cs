using PlanFort.Models.APIModels.OpenWeatherAPIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlanFort.Services
{
    public class OpenWeatherClient
    {
        private readonly HttpClient _openWeatherClient;

        public OpenWeatherClient(HttpClient openWeatherClient)
        {
            _openWeatherClient = openWeatherClient;
        }
        public async Task<WeatherResponseModel> GetWeatherByCity(string city)
        {
            var response = await _openWeatherClient.GetAsync($"data/2.5/weather?q={city}&appid=");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                var model = await JsonSerializer.DeserializeAsync<WeatherResponseModel>(content);

                return model;
            }
            else
            {
                throw new HttpRequestException("Open Weather API bad resposne");
            }

        }

    }
}
