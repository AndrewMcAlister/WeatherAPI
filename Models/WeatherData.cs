using Newtonsoft.Json;

namespace WeatherAPI.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public object Coord { get; set; } = new object();
        public List<Weather> Weather { get; set; } = new List<Weather>();
        public string Base { get; set; } = string.Empty;
        public object Main { get; set; } = new object();
        public int Visibility { get; set; }
        public object Wind { get; set; } = new object();
        public object Rain { get; set; } = new object();
        public object Clouds { get; set; } = new object();
        public int Dt { get; set; }
        public object Sys { get; set; } = new object();
        public int TimeZone { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonProperty("Cod")]
        public int StatusCode { get; set; }
    }
}
