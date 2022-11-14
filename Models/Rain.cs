using Newtonsoft.Json;

namespace WeatherAPI.Models
{
    public class Rain
    {
        [JsonProperty(PropertyName = "1h")]
        public float H1 { get; set; }
    }
}
