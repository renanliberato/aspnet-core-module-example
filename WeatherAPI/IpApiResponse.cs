using System.Runtime.Serialization;

namespace WeatherAPI
{
    [DataContract]
    public class IpApiResponse
    {
        [DataMember]
        public float latitude { get; set; }
        
        [DataMember]
        public float longitude { get; set; }
    }
}
