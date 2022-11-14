namespace WeatherAPI.Models
{
    public class WeatherContext
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}