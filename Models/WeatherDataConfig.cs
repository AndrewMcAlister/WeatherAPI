using WeatherAPI.Interfaces;

namespace WeatherAPI.Models
{
    public class WeatherDataConfig : IWeatherDataConfig
    {
        public string BaseUrl { get; set; } = string.Empty;
        public List<string> Key { get; set; } = new List<string>();
    }
}
