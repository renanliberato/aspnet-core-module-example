using System.Threading.Tasks;

namespace WeatherAPI.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecast> GetWeather(float latitude, float longitude);
    }
}
