using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeatherAPI.Interfaces;
using WeatherAPI.Models;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> logger;
        private readonly IWeatherService weatherService;

        public WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService, IWeatherDataConfig weatherDataConfig)
        {
            this.logger = logger;
            this.weatherService = weatherService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [LimitRequest(MaxRequests = 5, TimeWindow = 3600)]
        public async Task<IActionResult> GetAsync(string country, string city)
        {
            try
            {
                var weatherData = await weatherService.GetWeatherDescription(country, city, base.HttpContext);
                if (weatherData != null)
                    return Ok(weatherData);
                else
                    return BadRequest("Please enter valid data");
            }
            catch (Exception ex)
            {
                return (IActionResult)(new HttpRequestException(ex.Message, ex, HttpStatusCode.InternalServerError));
            }

        }
    }
}