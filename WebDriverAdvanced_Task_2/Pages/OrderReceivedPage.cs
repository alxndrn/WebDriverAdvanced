using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace WebDriverAdvanced_Task_2.Pages
{
    class OrderReceivedPage : BasePage
    {
        public OrderReceivedPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement OrderReceivedHeading => _driver.FindElement(By.XPath("//*[@id='post-7']/header/h1"));

        public bool isOrderReceivedHeadingDisplayed()
        {
            return OrderReceivedHeading.Displayed;
        }
        public bool isQuantity3Displayed()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var quantity3Label = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//strong[contains(text(),'3')]")));
            return quantity3Label.Displayed;
        }
    }
}
