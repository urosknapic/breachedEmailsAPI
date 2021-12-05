namespace BreachedEmailsAPI.Interfaces
{
  public interface IRedisCacheService
  {
    T Get<T>(string key);
    T Set<T>(string key, T value);
    bool ContainsKey(string key);
    bool RemoveKey(string key);
  }
}
