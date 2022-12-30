using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeatherTypes.Interfaces;
using WeatherTypes.Models;

namespace WeatherAPI.Controllers
{
    /// <summary>
    /// This is a small sample .Net 7 API to return a weather forecast, I developed it from scratch.
    /// Can return detailed Weather for a given location
    /// Or brief weather message
    /// Or a continious stream of weather data for the worlds cities - suitable for a ticker.
    /// </summary>
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIResponse<WeatherData?>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [LimitRequest(MaxRequests = 50, TimeWindow = 3600)]
        public async Task<ActionResult<WeatherData?>> GetAsync(string country, string city)
        {
            APIResponse<WeatherData?> apiResponse;
            try
            {
                var weatherData = await weatherService.GetAllWeather(country, city, base.HttpContext);
                apiResponse = new APIResponse<WeatherData?>() { Data = weatherData, StatusCode = (HttpStatusCode)base.HttpContext.Response.StatusCode, Message="" };

                return StatusCode(base.HttpContext.Response.StatusCode, apiResponse);
            }
            catch (Exception ex)
            {
                //In production code the middleware would...
                //log the true message
                //return a simpler message to the front-end with a code that links to the log
                return StatusCode(base.HttpContext.Response.StatusCode, ex.Message);
            }
        }

        [HttpGet("Brief")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(APIResponse<string>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [LimitRequest(MaxRequests = 5, TimeWindow = 3600)]
        public async Task<ActionResult<string>> GetAsyncDesc(string country, string city)
        {
            var apiResponse = new APIResponse<string>();
            try
            {
                var weatherData = await weatherService.GetWeatherBrief(country, city, base.HttpContext);
                var resp = new APIResponse<string>() { StatusCode = (HttpStatusCode)base.HttpContext.Response.StatusCode, Message = weatherData };

                return StatusCode(base.HttpContext.Response.StatusCode, resp);
            }
            catch (Exception ex)
            {
                //In production code the middleware would...
                //log the true message
                //return a simpler message to the front-end with a code that links to the log
                return StatusCode(base.HttpContext.Response.StatusCode, ex.Message);
            }
        }

        [HttpGet("World")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IAsyncEnumerable<WeatherData>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        [LimitRequest(MaxRequests = 50, TimeWindow = 3600)]
        public async IAsyncEnumerable<WeatherData> GetWorldCapitolWeatherStream()
        {
            await foreach (var wd in weatherService.GetWorldCapitalWeather(base.HttpContext))
            {
                yield return wd; //yield cannot be within a try-catch block, so GetWorldCapitalWeather would need a try-catch block
            }
        }
    }
}