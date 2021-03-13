using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace WebDriverAdvanced_Task_1.Pages
{
    class GoogleMapsPage : BasePage
    {
        public GoogleMapsPage(IWebDriver driver) : base(driver)
        {
        }

        public void waitToLoadAndClickAccept()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var frame = wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//*[@id='consent-bump']/div/div[1]/iframe")));
            var acceptButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("introAgreeButton")));
            acceptButton.Click();

            _driver.SwitchTo().DefaultContent();
        }
    }
}
