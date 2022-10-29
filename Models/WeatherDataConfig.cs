using WeatherAPI.Interfaces;

namespace WeatherAPI.Models
{
    public class WeatherDataConfig : IWeatherDataConfig
    {
        public string BaseUrl { get; set; } = string.Empty;
        public List<string> Keys { get; set; } = new List<string>();
        public bool AllowAllKeys { get; set; } = false;
    }
}
