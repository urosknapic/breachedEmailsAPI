namespace BreachedEmailsAPI.Interfaces
{
  public interface IEmailStorageService
  {
    string GetEmail(string email);
    bool AddEmail(string email);
    bool RemoveEmail(string email);
  }
}
