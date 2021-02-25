using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherAPI.Services;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IIpLocationService _ipLocationService;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IIpLocationService ipLocationService, IWeatherService weatherService)
        {
            _ipLocationService = ipLocationService;
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<WeatherForecast> Get()
        {
            var location = await _ipLocationService.GetLocation(this.HttpContext.Connection.RemoteIpAddress);

            return await _weatherService.GetWeather(location.latitude, location.longitude);
        }
    }
}
