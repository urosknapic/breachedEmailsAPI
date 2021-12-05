using BreachedEmailsAPI.Interfaces;

namespace BreachedEmailsAPI.Services
{
  public class EmailStorageService : IEmailStorageService
  {
    private Dictionary<string, int> _emails;

    public EmailStorageService()
    {
      _emails = new Dictionary<string, int>();
    }

    public bool AddEmail(string email)
    {
      if (_emails.ContainsKey(email))
      {
        return false;
      }
      _emails.Add(email, 1);
      return true;
    }

    public string GetEmail(string email)
    {
      return email;
    }

    public bool RemoveEmail(string email)
    {
      throw new NotImplementedException();
    }

    public int GetEmailsCount()
    {
      return _emails.Count;
    }
  }
}
