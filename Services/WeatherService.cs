using Newtonsoft.Json;
using System.Net;
using WeatherAPI.Interfaces;
using WeatherAPI.Models;

namespace WeatherAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherDataConfig weatherDataConfig;
        private readonly IRateLimiter rateLimiter;

        private const string apiVersion = "2.5"; //we might have another similar classes written to other versions

        public WeatherService(IWeatherDataConfig weatherDataConfig, IRateLimiter rateLimiter)
        {
            this.weatherDataConfig = weatherDataConfig;
            this.rateLimiter = rateLimiter;
        }

        public async Task<IAsyncEnumerable<WeatherData>> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Just Gets Description.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<WeatherData?> GetAllWeather(string country, string city, HttpContext context)
        {
            WeatherData? wd = null;
            string errorMessage = string.Empty;
            try
            {
                if (weatherDataConfig.Keys.Any())
                {
                    var keyTuple = await FindAKeyThatsNotUsedUp(context);

                    //rate limit
                    if (await rateLimiter.CanCall(context, keyTuple.cacheKey))
                    {
                        var client = new HttpClient();
                        var url = $"{weatherDataConfig.BaseUrl}/{apiVersion}/weather?q={city},{country}&appid={keyTuple.apiKey}";
                        var respStr = await client.GetStringAsync(url);
                        if (!string.IsNullOrEmpty(respStr))
                            wd = JsonConvert.DeserializeObject<WeatherData>(respStr);

                        await rateLimiter.UpdateClientStatisticsAsync(context, keyTuple.cacheKey);
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                        errorMessage = "The hourly limit has been exceeded";
                    }
                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorMessage = "No Api keys exist";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {
                    //remote site incorrectly throws 404, not found (normally intended for missing web pages)
                    //could be wrong user input or could be corrent, but no data, so not an error, use whatever status code the remote site gave us
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorMessage = "No weather was found for that location";
                }
                else
                {
                    errorMessage = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //we don't know without user parameter validation enhancement
                }
            }

            if(errorMessage != string.Empty)
                throw new Exception(errorMessage);

            return wd;
        }

        /// <summary>
        /// Just Gets Description.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<string> GetWeatherBrief(string country, string city, HttpContext context)
        {
            WeatherData? wd = await GetAllWeather(country, city, context);
            if (wd != null)
                return string.Join(" and ", wd.Weather.Select(p => p.Description));
            else
                return String.Empty;
        }

        /// <summary>
        /// This is our key scheme - it looks at appsettings.json to see if we are allowed to try all the keys if one is used up
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task<(string apiKey, string cacheKey)> FindAKeyThatsNotUsedUp(HttpContext context)
        {
            string cacheKey = string.Empty;
            string apiKey = string.Empty;
            if (!weatherDataConfig.AllowAllKeys)
            {
                apiKey = weatherDataConfig.Keys[0];
                cacheKey = rateLimiter.GenerateClientKey(context, apiKey);
            }
            else
            {
                foreach (var key in weatherDataConfig.Keys)
                {
                    apiKey = key;
                    cacheKey = rateLimiter.GenerateClientKey(context, key);
                    if (await rateLimiter.CanCall(context, cacheKey))
                    {
                        break;
                    }
                }
            }

            return (apiKey,cacheKey);
        }
        
    }
}
