using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherAPI.Services
{
    public class IpApiLocationService : IIpLocationService
    {
        private HttpClient _httpClient;

        public IpApiLocationService()
        {
            this._httpClient = new HttpClient();
            this._httpClient.BaseAddress = new Uri("https://ipapi.co");
        }

        public async Task<IpApiResponse> GetLocation(System.Net.IPAddress ip)
        {
            var res = await this._httpClient.GetAsync($"/{ip}/json/");

            if (!res.IsSuccessStatusCode)
                throw new Exception("Could not get ip location");

            return JsonConvert.DeserializeObject<IpApiResponse>(await res.Content.ReadAsStringAsync());
        }
    }
}
