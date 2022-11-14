namespace WeatherAPI.Models
{
    public class Country
    {
        public string Name { get; set; } = string.Empty;
        public List<City> Cities { get; set; } = new List<City>();
    }
}
