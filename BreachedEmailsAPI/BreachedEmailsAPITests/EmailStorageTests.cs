using BreachedEmailsAPI.Interfaces;
using BreachedEmailsAPI.Services;
using NUnit.Framework;

namespace BreachedEmailsAPITests
{
  public class EmailStorageTests
  {
    public EmailStorageTests()
    {

    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void EmailStorage_WhenAdd_ReturnTrue()
    {
      // ARRANGE
      var service = new EmailStorageService();
      var email = "something@gmail.com";
      // ACT
      var result = service.AddEmail(email);
      // ASSERT
      Assert.AreEqual(result, true);
    }
  }
}