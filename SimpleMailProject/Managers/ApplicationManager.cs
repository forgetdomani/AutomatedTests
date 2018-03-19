using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;


namespace SimpleMailProject.Managers
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string BaseUrl;
        protected MailLoginManager MailLoginManager;
        protected NavigationManager NavigationManager;     
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new ChromeDriver();
            BaseUrl = "https://mail.rambler.ru/";
            MailLoginManager = new MailLoginManager(this);
            NavigationManager = new NavigationManager(this, BaseUrl);
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
                appManager.Navigator.OpenMailHomePage();
            }
            return app.Value;
        }

        public IWebDriver Driver { get { return driver; } }
        public MailLoginManager Auth { get { return MailLoginManager; } }
        public NavigationManager Navigator { get { return NavigationManager; } }
           
    }
}
