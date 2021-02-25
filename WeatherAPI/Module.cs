using Microsoft.Extensions.DependencyInjection;
using WeatherAPI.Services;

namespace WeatherAPI
{
    public static class Module
    {
        public static void InitServices(IServiceCollection services)
        {
            services.AddSingleton<IWeatherService, SevenTimerWeatherService>();
            services.AddSingleton<IIpLocationService, IpApiLocationService>();
        }
    }
}
