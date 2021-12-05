using BreachedEmailsAPI.Services;
using NUnit.Framework;

namespace BreachedEmailsAPITests
{
  public class EmailStorageTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void WhenAddEmail_ReturnTrue()
    {
      var service = new EmailStorageService();
      var email = "something@gmail.com";

      var result = service.AddEmail(email);

      Assert.AreEqual(result, true);
    }

    [Test]
    public void WhenAddEmailAndGetEmail_ReturnEmail()
    {
      var service = new EmailStorageService();
      var email = "something@gmail.com";

      var addReuslt = service.AddEmail(email);
      var result = service.GetEmail(email);

      Assert.AreEqual(addReuslt, true);
      Assert.AreEqual(result, email);
    }

    [Test]
    public void WhenAddOneEmail_GetCount1()
    {
      var service = new EmailStorageService();
      var email = "something@gmail.com";

      var addReuslt = service.AddEmail(email);
      var resultCount = service.GetEmailsCount();

      Assert.AreEqual(addReuslt, true);
      Assert.AreEqual(resultCount, 1);
    }
    [Test]
    public void WhenAddTwoEmails_GetCount2()
    {
      var service = new EmailStorageService();
      var emailOne = "something@gmail.com";
      var emailTwo = "somethingForSure@gmail.com";

      var firstEmailResult = service.AddEmail(emailOne);
      var secondEmailResult = service.AddEmail(emailTwo);

      var resultCount = service.GetEmailsCount();

      Assert.AreEqual(firstEmailResult, true);
      Assert.AreEqual(secondEmailResult, true);
      Assert.AreEqual(resultCount, 2);
    }

    [Test]
    public void WhenAddTwoIdenticalEmails_GetTrueFirstAndFalseSecond()
    {
      var service = new EmailStorageService();
      var email = "something@gmail.com";

      var firstEmailResult = service.AddEmail(email);
      var secondEmailResult = service.AddEmail(email);

      var resultCount = service.GetEmailsCount();

      Assert.AreEqual(firstEmailResult, true);
      Assert.AreEqual(secondEmailResult, false);
      Assert.AreEqual(resultCount, 1);
    }
  }
}