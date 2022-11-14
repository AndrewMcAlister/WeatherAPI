using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace WeatherAPI.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public Coordinate Coord { get; set; } = new Coordinate();
        public List<Weather> Weather { get; set; } = new List<Weather>();
        public string Base { get; set; } = string.Empty;
        public CoreMeasure Main { get; set; } = new CoreMeasure();
        public int Visibility { get; set; }
        public Wind Wind { get; set; } = new Wind();
        public Rain Rain { get; set; } = new Rain();
        public Cloud Clouds { get; set; } = new Cloud();
        public int Dt { get; set; }
        public WeatherContext Sys { get; set; } = new WeatherContext();
        public int TimeZone { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonProperty("Cod")]
        public int StatusCode { get; set; }
    }
}
