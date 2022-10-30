using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using System.Net;
using System.Text;
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

        /// <summary>
        /// Just Gets Description.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<string> GetWeatherDescription(string country, string city, HttpContext context)
        {
            WeatherData wd = null;
            string message = string.Empty;
            try
            {
                if (!weatherDataConfig.Keys.Any())
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    return "No Api keys exist";
                }

                var keyTuple = await FindAKeyThatWorks(context);

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
                    message = "The hourly limit has been exceeded"; 
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {
                    //remote site incorrectly throws 404, not found (normally intended for missing web pages)
                    //could be wrong user input or could be corrent, but no data, so not an error, use whatever status code the remote site gave us
                    message = "No weather was found for that location";
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                }
                else
                {
                    message = ex.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; //we don't know without user parameter validation enhancement
                }
            }

            if (wd != null)
                message = string.Join(" and ", wd.Weather.Select(p => p.Description));

            return message;
        }

        /// <summary>
        /// This is our key scheme - it looks at appsettings.json to see if we are allowed to try all the keys if one is used up
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task<(string apiKey, string cacheKey)> FindAKeyThatWorks(HttpContext context)
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
