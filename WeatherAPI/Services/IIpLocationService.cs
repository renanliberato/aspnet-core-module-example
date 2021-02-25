using System.Threading.Tasks;

namespace WeatherAPI.Services
{
    public interface IIpLocationService
    {
        Task<IpApiResponse> GetLocation(System.Net.IPAddress ip);
    }
}
