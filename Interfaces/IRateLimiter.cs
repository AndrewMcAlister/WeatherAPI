namespace WeatherAPI.Interfaces
{
    public interface IRateLimiter
    {
        Task<bool> CanCall(HttpContext context, string cacheKey);
        string GenerateClientKey(HttpContext context, string apiKey = null);
        Task UpdateClientStatisticsAsync(HttpContext context, string key);
    }
}