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
      _redisCache.Set<string>(email, email);

      var key = email;

      var emailCheck = new MailAddress(email).Address;
      if(_emails == null)
      {
        _emails = new Dictionary<string, int>();
      }

      if (_emails.ContainsKey(emailCheck.ToString()))
      {
        return false;
      }
      _emails.Add(email.ToString(), 1);
      return true;
    }

    public string GetEmail(string email)
    {
      if (_emails.ContainsKey(email))
      {
        return email;
      }

      return string.Empty;
    }

    public bool DeleteEmail(string email)
    {
      return _emails.Remove(email);
    }

    public int GetEmailsCount()
    {
      return _emails.Count;
    }
  }
}
