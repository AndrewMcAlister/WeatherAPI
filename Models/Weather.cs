﻿namespace WeatherAPI.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }
}