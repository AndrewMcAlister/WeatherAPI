using System.Net;
using WeatherAPI.Models;
using Microsoft.Extensions.Caching.Distributed;
using WeatherAPI.Extensions;
using WeatherAPI.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WeatherAPI.BusinessLogic
{
    public class RateLimiter : IRateLimiter
    {
        private readonly IDistributedCache cache;

        public RateLimiter(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public async Task<bool> CanCall(HttpContext context,string cacheKey)
        {
            // read the LimitRequest attribute from the endpoint
            var rateLimitDecorator = GetRateLimitRequest(context);

            if (rateLimitDecorator is null)
            {
                return true;
            }

            var clientStatistics = GetClientStatisticsByKey(cacheKey).Result;

            // Check whether the request violates the rate limit policy
            if (clientStatistics != null
                && DateTime.Now < clientStatistics.FirstResponseTime.AddSeconds(rateLimitDecorator.TimeWindow)
                && clientStatistics.NumberofRequestsCompletedSuccessfully == rateLimitDecorator.MaxRequests)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// generate ClientKey from the context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual string GenerateClientKey(HttpContext context, string apiKey)
        {
            var cacheKey = $"{context.Request.Path}_{context.Connection.RemoteIpAddress}_{apiKey}";

            return cacheKey;
        }

        /// <summary>
        /// Get the client statistics from caching
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private async Task<ClientStatistics> GetClientStatisticsByKey(string key)
         => await cache.GetCachedValueAsyn<ClientStatistics>(key);

        public async Task UpdateClientStatisticsAsync(HttpContext context, string key)
        {
            var rateLimitDecorator = GetRateLimitRequest(context);
            var clientStats = cache.GetCachedValueAsyn<ClientStatistics>(key).Result;
            if (clientStats is not null)
            {
                clientStats.FirstResponseTime = DateTime.Now;
                if (clientStats.NumberofRequestsCompletedSuccessfully == rateLimitDecorator.MaxRequests)
                    clientStats.NumberofRequestsCompletedSuccessfully = 1;
                else
                    clientStats.NumberofRequestsCompletedSuccessfully++;

                await cache.SetCachedValueAsync<ClientStatistics>(key, clientStats);
            }
            else
            {
                var clientStatsNew = new ClientStatistics
                {
                    FirstResponseTime = DateTime.Now,
                    NumberofRequestsCompletedSuccessfully = 1
                };

                await cache.SetCachedValueAsync<ClientStatistics>(key, clientStatsNew);
            }
        }

        private LimitRequest? GetRateLimitRequest(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var rateLimitDecorator = endpoint?.Metadata?.GetMetadata<LimitRequest>();
            return rateLimitDecorator;
        }
    }
}
