using NUnit.Framework;
using CompareAppProject.Managers;

namespace CompareAppProject.Tests
{
    public class TestBase
    {
        protected ApplicationManager AppManager;

        [SetUp]
        public void SetupApplicationManager()
        {
            AppManager = ApplicationManager.GetInstance();
        }
        [TearDown]
        public void TeardownTest()
        {

        }
    }
}