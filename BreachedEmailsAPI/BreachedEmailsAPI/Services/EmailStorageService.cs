using BreachedEmailsAPI.Interfaces;
using System.Net.Mail;

namespace BreachedEmailsAPI.Services
{
  public class EmailStorageService : IEmailStorageService
  {
    private Dictionary<string, int> _emails;

    public EmailStorageService()
    {
      _emails = new Dictionary<string, int>();
    }

    //   T:System.FormatException:
    //     address is not in a recognized format. -or- address contains non-ASCII 
    public bool AddEmail(string email)
    {
      var emailCheck = new MailAddress(email).Address;

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
