using Newtonsoft.Json;

namespace WeatherAPI.Models
{
    public class CoreMeasure
    {
        public float? Temp { get; set; }
        [JsonProperty(PropertyName = "feels_like")]
        public string? FeelsLike { get; set; }
        [JsonProperty(PropertyName = "temp_min")]
        public float? TempMin { get; set; }
        [JsonProperty(PropertyName = "temp_max")]
        public float? TempMax { get; set; }
        public int? Pressure { get; set; }
        public int? Humidity { get; set; }
        [JsonProperty(PropertyName = "sea_level")]
        public int? SeaLevel { get; set; }
        [JsonProperty(PropertyName = "grnd_level")]
        public int? GroundLevel { get; set; }
    }
}
