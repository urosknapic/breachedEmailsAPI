using Autofac.Extras.Moq;
using BreachedEmailsAPI.Interfaces;
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

    [Test]
    public void WhenDeleteEmailThatDoesNotExist_ReturnFalse()
    {
      using (var mock = AutoMock.GetLoose())
      {
        var email = "something@gmail.com";
        mock.Mock<IEmailStorageService>()
          .Setup(x => x.DeleteEmail(email))
          .Returns(false);

        var service = mock.Create<IEmailStorageService>();

        Assert.IsFalse(service.DeleteEmail(email));
      }
    }

    [Test]
    public void WhenDeleteEmailAfterInsert_ReturnTrue()
    {
      using (var mock = AutoMock.GetLoose())
      {
        var email = "something@gmail.com";
        mock.Mock<IEmailStorageService>()
          .Setup(x => x.DeleteEmail(email))
          .Returns(false);
        mock.Mock<IEmailStorageService>()
          .Setup(x => x.AddEmail(email))
          .Returns(true);
        mock.Mock<IEmailStorageService>()
          .Setup(x => x.DeleteEmail(email))
          .Returns(true);

        var service = mock.Create<IEmailStorageService>();

        Assert.IsTrue(service.DeleteEmail(email));
      }
    }

    [Test]
    public void WhenGetNotExistingEmail_ReturnEmptyString()
    {
      using (var mock = AutoMock.GetLoose())
      {
        var email = "something@gmail.com";
        mock.Mock<IEmailStorageService>()
          .Setup(x => x.GetEmail(email))
          .Returns(string.Empty);

        var service = mock.Create<IEmailStorageService>();

        var result = service.GetEmail(email);

        Assert.AreEqual(result, string.Empty);
      }
    }

    [Test]
    public void WhenGetEmailAfterInsert_ReturnEmail()
    {
      using (var mock = AutoMock.GetLoose())
      {
        var email = "something@gmail.com";

        mock.Mock<IEmailStorageService>()
          .Setup(x => x.AddEmail(email))
          .Returns(true);
        mock.Mock<IEmailStorageService>()
          .Setup(x => x.GetEmail(email))
          .Returns(email);

        var service = mock.Create<IEmailStorageService>();

        var result = service.GetEmail(email);

        Assert.AreEqual(result, "something@gmail.com");
      }
    }
  }
}