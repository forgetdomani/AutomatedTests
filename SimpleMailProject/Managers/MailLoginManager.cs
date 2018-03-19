using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SimpleMailProject.Models;

namespace SimpleMailProject.Managers
{
    public class MailLoginManager : ManagerBase
    {
        public MailLoginManager(ApplicationManager manager) : base(manager) { }
        public void Login(MailAccountData account)
        {
          
            Driver.FindElement(By.Name("login")).Click();
            Type(By.Name("login"), account.Username);
            Type(By.Name("password"), account.Password);
            Driver.FindElement(By.CssSelector(("button[type=\"submit\"]"))).Click();
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.ClassName("Profile-email-OI"));
        }
        public bool IsLoggedIn(MailAccountData account)
        {
            return IsLoggedIn() &&
                   Driver.FindElement(By.ClassName("Profile-email-OI")).Text == String.Format("{0}@rambler.ru",account.Username);
        }
        public bool HasLoggedIn()
        {
            try
            {
                var wait = new WebDriverWait(Manager.Driver, TimeSpan.FromSeconds(60));
                wait.Until(ExpectedConditions.ElementExists(By.ClassName("Profile-email-OI")));
                return IsElementPresent(By.ClassName("Profile-email-OI"));
            }
            catch { return false; }
        }
        public bool HasLoggedIn(MailAccountData account)
        {
            return HasLoggedIn() &&
                   Driver.FindElement(By.ClassName("Profile-email-OI")).Text == String.Format("{0}@rambler.ru", account.Username);
        }
        public void Logout()
        {
            if (IsLoggedIn())
            {
                Driver.FindElement(By.ClassName("Profile-exit-2_")).Click();
            }

        }
        public bool IsInvalidCredentialMessage()
        {
            return IsElementPresent(By.ClassName("form-msg__content"));
        }
    }

}