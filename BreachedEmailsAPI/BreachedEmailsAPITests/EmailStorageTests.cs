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

      Assert.IsTrue(result);
    }

    [Test]
    public void WhenAddEmailAndGetEmail_ReturnEmail()
    {
      var service = new EmailStorageService();
      var email = "something@gmail.com";

      var addReuslt = service.AddEmail(email);
      var countEmailsResult = service.GetEmailsCount();
      var result = service.GetEmail(email);

      Assert.IsTrue(addReuslt);
      Assert.AreEqual(countEmailsResult, 1);
      Assert.AreEqual(result, email);
    }

    [Test]
    public void WhenAddOneEmail_GetCount1()
    {
      var service = new EmailStorageService();
      var email = "something@gmail.com";

      var addReuslt = service.AddEmail(email);
      var resultCount = service.GetEmailsCount();

      Assert.IsTrue(addReuslt);
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

      Assert.IsTrue(firstEmailResult);
      Assert.IsTrue(secondEmailResult);
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

      Assert.IsTrue(firstEmailResult);
      Assert.IsFalse(secondEmailResult);
      Assert.AreEqual(resultCount, 1);
    }

    [Test]
    public void WhenDeleteEmailFromEmptyStorage_ReturnFalse()
    {
      var service = new EmailStorageService();
      var email = "something@gmail.com";

      var result = service.DeleteEmail(email);

      Assert.IsFalse(result);
    }
    [Test]
    public void WhenDeleteEmailAfterInserting_ReturnTrue()
    {
      var service = new EmailStorageService();
      var email = "something@gmail.com";

      var addResult = service.AddEmail(email);
      var deleteResult = service.DeleteEmail(email);

      Assert.IsTrue(addResult);
      Assert.IsTrue(deleteResult);
    }

    [Test]
    public void WhenDeleteEmailAfterInsert_GetEmptyStringForGettingEmail()
    {
      var service = new EmailStorageService();
      var email = "something@gmail.com";

      service.AddEmail(email);
      service.DeleteEmail(email);
      var getEmail = service.GetEmail(email);

      Assert.AreEqual(getEmail, string.Empty);
    }

  }
}