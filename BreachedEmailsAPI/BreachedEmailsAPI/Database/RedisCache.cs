using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace BreachedEmailsAPI.Database
{
  public static class RedisCache
  {
    public static async Task SetRecordAsync<T>(this IDistributedCache cache,
      string key,
      T data,
      TimeSpan? expireTime = null,
      TimeSpan? unusedExpireTime = null)
    {
      var options = new DistributedCacheEntryOptions();
      options.AbsoluteExpirationRelativeToNow = expireTime;
      options.SlidingExpiration = unusedExpireTime;
      var json = JsonSerializer.Serialize(data);
      await cache.SetStringAsync(key, json, options);
    }

    public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache, string key)
    {
      var jsonData = await cache.GetStringAsync(key);
      if(jsonData == null)
      {
        return default(T);
      }
      return JsonSerializer.Deserialize<T>(jsonData);
    }
  }
}
