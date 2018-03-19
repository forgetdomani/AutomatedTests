using OpenQA.Selenium;


namespace CompareAppProject.Managers
{
    public class ManagerBase
    {
        protected IWebDriver Driver;
        protected ApplicationManager Manager;
        public ManagerBase(ApplicationManager manager)
        {
            Manager = manager;
            Driver = manager.Driver;
        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                Driver.FindElement(locator).Clear();
                Driver.FindElement(locator).SendKeys(text);
            }
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
