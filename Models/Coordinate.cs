using Newtonsoft.Json;

namespace WeatherAPI.Models
{
    public class Coordinate
    {
        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }
        [JsonProperty(PropertyName = "lon")]
        public double Longitude { get; set; }
    }
}
