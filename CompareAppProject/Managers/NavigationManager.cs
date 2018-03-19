using OpenQA.Selenium.Support.UI;

namespace CompareAppProject.Managers
{
    public class NavigationManager : ManagerBase
    {
        private readonly string _baseUrl;
        public NavigationManager(ApplicationManager manager, string baseUrl) : base(manager)
        {
            _baseUrl = baseUrl;
        }
        public void OpenHomePage()
        {
            if (Driver.Url != _baseUrl)
            {
                Driver.Navigate().GoToUrl(_baseUrl);
                
            }
        }
    }
}
