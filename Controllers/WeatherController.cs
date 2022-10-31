using Microsoft.AspNetCore.Mvc;
using System.IO.Pipes;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIResponse<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [LimitRequest(MaxRequests = 5, TimeWindow = 3600)]
        public async Task<ActionResult> GetAsync(string country, string city)
        {
            var apiResponse = new APIResponse<string>();
            try
            {
                var weatherData = await weatherService.GetWeatherDescription(country, city, base.HttpContext);
                var resp = new APIResponse<string>() { StatusCode = (HttpStatusCode)base.HttpContext.Response.StatusCode, Message= weatherData };

                return StatusCode(base.HttpContext.Response.StatusCode, resp);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,ex.Message);
            }
        }
    }
}