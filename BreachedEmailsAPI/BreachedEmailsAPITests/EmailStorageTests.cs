using Autofac.Extras.Moq;
using BreachedEmailsAPI.Interfaces;
using BreachedEmailsAPI.Services;
using Microsoft.Extensions.Caching.Distributed;
using Moq;
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
      var email = "something@gmail.com";
      using (var mock = AutoMock.GetLoose())
      {
        mock.Mock<IEmailStorageService>()
          .Setup(x => x.AddEmail(email))
          .Returns(true);

        var service = mock.Create<EmailStorageService>();

        var result = service.AddEmail(email);

        Assert.IsTrue(result);
      }
    }


    [Test]
    public void WhenAddEmailTwice_ReturnFalse()
    {
      using (var mock = AutoMock.GetLoose())
      {
        var email = "something@gmail.com";
        mock.Mock<IEmailStorageService>()
          .Setup(x => x.AddEmail(email))
          .Returns(true);
        mock.Mock<IEmailStorageService>()
          .Setup(x => x.AddEmail(email))
          .Returns(false);

        var service = mock.Create<IEmailStorageService>();
        Assert.IsFalse(service.AddEmail(email));
      }
    }

    //[Test]
    //public void WhenAddEmailAndGetEmail_ReturnEmail()
    //{
    //  //var service = new EmailStorageService();
    //  var email = "something@gmail.com";

    //  var addReuslt = _emailService.AddEmail(email);
    //  //var countEmailsResult = _email_emailService.GetEmailsCount();
    //  var result = _emailService.GetEmail(email);

    //  Assert.IsTrue(addReuslt);
    //  //Assert.AreEqual(countEmailsResult, 1);
    //  Assert.AreEqual(result, email);
    //}

    //[Test]
    //public void WhenAddOneEmail_GetCount1()
    //{
    //  //var service = new EmailStorageService();
    //  var email = "something@gmail.com";

    //  var addReuslt = _emailService.AddEmail(email);
    //  //var resultCount = _emailService.GetEmailsCount();

    //  Assert.IsTrue(addReuslt);
    //  //Assert.AreEqual(resultCount, 1);
    //}
    //[Test]
    //public void WhenAddTwoEmails_GetCount2()
    //{
    //  //var service = new EmailStorageService();
    //  var emailOne = "something@gmail.com";
    //  var emailTwo = "somethingForSure@gmail.com";

    //  var firstEmailResult = _emailService.AddEmail(emailOne);
    //  var secondEmailResult = _emailService.AddEmail(emailTwo);

    //  //var resultCount = _emailService.GetEmailsCount();

    //  Assert.IsTrue(firstEmailResult);
    //  Assert.IsTrue(secondEmailResult);
    //  //Assert.AreEqual(resultCount, 2);
    //}

    //[Test]
    //public void WhenAddTwoIdenticalEmails_GetTrueFirstAndFalseSecond()
    //{
    //  var email = "something@gmail.com";

    //  var firstEmailResult = _emailService.AddEmail(email);
    //  var secondEmailResult = _emailService.AddEmail(email);

    //  //var resultCount = _emailService.GetEmailsCount();

    //  Assert.IsTrue(firstEmailResult);
    //  Assert.IsFalse(secondEmailResult);
    //  //Assert.AreEqual(resultCount, 1);
    //}

    //[Test]
    //public void WhenDeleteEmailFromEmptyStorage_ReturnFalse()
    //{
    //  var email = "something@gmail.com";

    //  var result = _emailService.DeleteEmail(email);

    //  Assert.IsFalse(result);
    //}
    //[Test]
    //public void WhenDeleteEmailAfterInserting_ReturnTrue()
    //{
    //  var email = "something@gmail.com";

    //  var addResult = _emailService.AddEmail(email);
    //  var deleteResult = _emailService.DeleteEmail(email);

    //  Assert.IsTrue(addResult);
    //  Assert.IsTrue(deleteResult);
    //}

    //[Test]
    //public void WhenDeleteEmailAfterInsert_GetEmptyStringForGettingEmail()
    //{
    //  var email = "something@gmail.com";

    //  _emailService.AddEmail(email);
    //  _emailService.DeleteEmail(email);
    //  var getEmail = _emailService.GetEmail(email);

    //  Assert.AreEqual(getEmail, string.Empty);
    //}

    //[Test]
    //public void WhenAddIncorectEmailFormat_ThrowExceptionForIncorectInput()
    //{
    //  var email = "thisisincorectemail";

    //  Assert.Throws<System.FormatException>(() => _emailService.AddEmail(email));
    //}

  }
}