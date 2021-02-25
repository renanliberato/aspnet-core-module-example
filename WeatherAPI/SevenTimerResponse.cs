using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WeatherAPI
{
    [DataContract]
    public class SevenTimerResponse
    {
        [DataMember]
        public IEnumerable<DataSeries> dataseries { get; set; }
    }
    
    [DataContract]
    public class DataSeries
    {
        [DataMember]
        public int timepoint { get; set; }

        [DataMember]
        public int temp2m { get; set; }
    }
}
