namespace WeatherAPI.Interfaces
{
    public interface IRateLimiter
    {
        Task<bool> CanCall(HttpContext context, string apiKey);
        string GenerateClientKey(HttpContext context, string apiKey = null);
    }
}