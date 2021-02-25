using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WeatherAPI.Services
{
    public class SevenTimerWeatherService : IWeatherService
    {
        private HttpClient _httpClient;

        public SevenTimerWeatherService()
        {
            this._httpClient = new HttpClient();
            this._httpClient.BaseAddress = new Uri("http://www.7timer.info");
        }

        public async Task<WeatherForecast> GetWeather(float latitude, float longitude)
        {
            var res = await this
                ._httpClient
                .GetAsync($"/bin/astro.php?lon={latitude}&lat={longitude}&ac=0&unit=metric&output=json&tzshift=0");

            if (!res.IsSuccessStatusCode)
            {
                throw new Exception("Could not get weather data");
            }

            var sevenTimerForecast = JsonConvert.DeserializeObject<SevenTimerResponse>(await res.Content.ReadAsStringAsync());

            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = sevenTimerForecast.dataseries.First().temp2m
            };
        }
    }
}
