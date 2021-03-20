using Microsoft.Extensions.Configuration;
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

        public OpenWeatherClient(HttpClient openWeatherClient, IConfiguration configuration)
        {
            _openWeatherClient = openWeatherClient;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<WeatherResponseModel> GetWeather(string city)
        {
            var appID = Configuration.GetSection("Weather:AppID").Value;

            var response = await _openWeatherClient.GetAsync($"data/2.5/weather?q={city}&units=imperial&appid={appID}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                var model = await JsonSerializer.DeserializeAsync<WeatherResponseModel>(content);

                return model;
            }
            else
            {
                throw new HttpRequestException("Open Weather API bad response");
            }
        }
    }
}
