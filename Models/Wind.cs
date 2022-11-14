using Newtonsoft.Json;

namespace WeatherAPI.Models
{
    public class Wind
    {
        public float Speed { get; set; }
        [JsonProperty(PropertyName = "deg")]
        public int Direction { get; set; }
        public float? Gust { get; set; }
    }
}
