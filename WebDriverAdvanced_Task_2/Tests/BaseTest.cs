using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverAdvanced_Task_2.Tests
{
    public class BaseTest
    {
        protected IWebDriver _driver;
        [TestInitialize]
        public void TestInit()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://demos.bellatrix.solutions/");
            _driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Quit();
        }
    }
}
