using OpenQA.Selenium;
using System;

namespace WebDriverAdvanced_Task_2.Pages
{
    public class BasePage
    {
        protected IWebDriver _driver;
        public BasePage(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException("Driver cannot be null.");
        }
    }
}
