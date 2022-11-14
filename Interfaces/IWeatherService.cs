using WeatherAPI.Models;

namespace WeatherAPI.Interfaces
{
    public interface IWeatherService
    {
        Task<string> GetWeatherBrief(string country, string city, HttpContext context);
        Task<WeatherData?> GetAllWeather(string country, string city, HttpContext context);
        IAsyncEnumerable<WeatherData> GetWorldCapitalWeather(HttpContext context);
    }
}