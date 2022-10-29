namespace WeatherAPI.Interfaces
{
    public interface IWeatherDataConfig
    {
        string BaseUrl { get; set; }
        List<string> Keys { get; set; }
        bool AllowAllKeys { get; set; }
    }
}