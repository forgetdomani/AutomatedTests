using SimpleMailProject.Managers;
using NUnit.Framework;

namespace SimpleMailProject.Tests
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