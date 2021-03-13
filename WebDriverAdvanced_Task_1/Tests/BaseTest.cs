using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverAdvanced_Task_1.Tests
{
    public class BaseTest
    {
        protected IWebDriver _driver;
        
        [TestInitialize]
        public void TestInit()
        {
            var driverOptions = new ChromeOptions();
            driverOptions.BrowserVersion = "86";

            _driver = new ChromeDriver();

            _driver.Navigate().GoToUrl("https://www.zip-codes.com/");
            _driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver.Quit();
        }
    }
}
