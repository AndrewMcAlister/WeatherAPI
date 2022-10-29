using Newtonsoft.Json;
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
                var apiKey = weatherDataConfig.Key[0];
                var client = new HttpClient();
                var url = $"{weatherDataConfig.BaseUrl}/{apiVersion}/weather?q={city},{country}&appid={apiKey}";
                //rate limit
                if (await rateLimiter.CanCall(context, apiKey))
                {

                    var respStr = await client.GetStringAsync(url);
                    if (!string.IsNullOrEmpty(respStr))
                        wd = JsonConvert.DeserializeObject<WeatherData>(respStr);
                }
                else
                    message = "The hourly limit has been exceeded";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            if (wd != null)
                message = string.Join(" and ", wd.Weather.Select(p=>p.Description));

            return message;
        }
        
    }
}
