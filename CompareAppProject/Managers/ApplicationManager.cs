using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;


namespace CompareAppProject.Managers
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string BaseUrl;
        protected NavigationManager NavigationManager;
        protected ComparisonManager ComparisonManager;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();            
            BaseUrl = "http://react-compare-app.surge.sh/";
            NavigationManager = new NavigationManager(this, BaseUrl);
            ComparisonManager = new ComparisonManager(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }



        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager appManager = new ApplicationManager();
                app.Value = appManager;
                appManager.Navigator.OpenHomePage();
            }
            return app.Value;
        }

        public IWebDriver Driver { get { return driver; } }
        public NavigationManager Navigator { get { return NavigationManager; } }
        public ComparisonManager Comparer { get { return ComparisonManager; } }

    }
}
