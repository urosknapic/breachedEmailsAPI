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
      throw new NotImplementedException();
    }

    public string GetEmail(string email)
    {
      throw new NotImplementedException();
    }

    public bool RemoveEmail(string email)
    {
      throw new NotImplementedException();
    }
  }
}
