namespace WeatherAPI.Interfaces
{
    public interface IWeatherDataConfig
    {
        string BaseUrl { get; set; }
        List<string> Key { get; set; }
    }
}