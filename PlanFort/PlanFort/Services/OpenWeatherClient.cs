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
        //public double GetTempByCity(string city)
        //{
        //    var weather = GetWeather(city);
        //    var temp = weather;
        //}
        public async Task<WeatherResponseModel> GetWeather(string city)
        {
            var response = await _openWeatherClient.GetAsync($"data/2.5/weather?q={city}&units=imperial&appid=26a6a596dfa6ff3649d805a3cf7dbc34");

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
