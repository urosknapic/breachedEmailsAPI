using BreachedEmailsAPI.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace BreachedEmailsAPI.Services
{
  public class RedisCacheService : IRedisCacheService
  {
    private readonly IDistributedCache _cache;
    public RedisCacheService(IDistributedCache cache)
    {
      _cache = cache;
    }

    public bool ContainsKey(string key)
    {
      var value = _cache.GetString(key);
      return value != null;
    }

    public T Get<T>(string key)
    {
      var value = _cache.GetString(key);

      if (value != null)
      {
        return JsonSerializer.Deserialize<T>(value);
      }

      return default(T);
    }

    public bool RemoveKey(string key)
    {
      var value = _cache.GetString(key);
      if (value != null)
      {
        _cache.Remove(key);
        return true;
      }
      return false;
    }

    public T Set<T>(string key, T value)
    {
      var timeOut = new DistributedCacheEntryOptions
      {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24),
        SlidingExpiration = TimeSpan.FromMinutes(60)
      };

      _cache.SetString(key, JsonSerializer.Serialize(value), timeOut);

      return value;
    }
  }
}
