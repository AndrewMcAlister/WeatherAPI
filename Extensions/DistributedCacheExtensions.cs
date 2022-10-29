using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherAPI.Extensions
{
    public static class DistributedCacheExtensions
    {
        public async static Task<T> GetCachedValueAsyn<T>(this IDistributedCache cache, string key, CancellationToken token = default(CancellationToken)) where T : class
        {
            var result = await cache.GetAsync(key, token);
            if (result != null)
                return result.FromByteArray<T>();
            else
                return default(T);
        }

        public async static Task SetCachedValueAsync<T>(this IDistributedCache cache, string key, T value, CancellationToken token = default(CancellationToken))
        {
            await cache.SetAsync(key, value.ToByteArray(), token);
        }

        public static T FromByteArray<T>(this byte[] data) where T : class
        {
            T result = default(T);
            using (var stream = new MemoryStream(data))
            {
                result = System.Text.Json.JsonSerializer.Deserialize<T>(stream);
            }
            return result;
        }

        public static byte[] ToByteArray(this object obj)
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(obj);
        }

    }
}
