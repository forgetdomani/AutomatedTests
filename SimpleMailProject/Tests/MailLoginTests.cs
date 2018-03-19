using NUnit.Framework;
using SimpleMailProject.Models;

namespace SimpleMailProject.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            AppManager.Auth.Logout();
            var accountData = new MailAccountData("yatestuserlogin", "Passw0rD");
            AppManager.Auth.Login(accountData);
            Assert.IsTrue(AppManager.Auth.HasLoggedIn(accountData));
        }
        [Test]
        public void LoginWithInvalidCredentials()
        {
            AppManager.Auth.Logout();
            var accountData = new MailAccountData("yatestuserlogin", "pASSWoRd");
            AppManager.Auth.Login(accountData);
            Assert.IsFalse(AppManager.Auth.IsLoggedIn(accountData));
            Assert.IsTrue(AppManager.Auth.IsInvalidCredentialMessage());
        }
       
    }
}

