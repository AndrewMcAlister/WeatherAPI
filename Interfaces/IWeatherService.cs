using WeatherAPI.Models;

namespace WeatherAPI.Interfaces
{
    public interface IWeatherService
    {
        Task<string> GetWeatherDescription(string country, string city, HttpContext context);
    }
}