using BreachedEmailsAPI.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Net.Mail;

namespace BreachedEmailsAPI.Services
{
  public class EmailStorageService : IEmailStorageService
  {
    private IRedisCacheService _redisCache;
    private Dictionary<string, int> _emails;

    public EmailStorageService(IRedisCacheService redisCache)
    {
      _redisCache = redisCache;
    }

    //   T:System.FormatException:
    //     address is not in a recognized format. -or- address contains non-ASCII 
    public bool AddEmail(string email)
    {
      var emailCheck = new MailAddress(email).Address;
      if (_redisCache.ContainsKey(emailCheck.ToString()))
      {
        return false;
      }
      _redisCache.Set(email.ToString(), 1);
      return true;
    }

    public string GetEmail(string email)
    {
      if (_redisCache.ContainsKey(email))
      {
        return _redisCache.Get<string>(email);
      }

      return string.Empty;
    }

    public bool DeleteEmail(string email)
    {
      return _redisCache.RemoveKey(email);
    }
  }
}
