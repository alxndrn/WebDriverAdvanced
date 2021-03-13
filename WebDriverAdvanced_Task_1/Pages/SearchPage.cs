using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace WebDriverAdvanced_Task_1.Pages
{
    public class SearchPage : BasePage
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement AdvancedSearchButton => _driver.FindElement(By.XPath("//body/table//ul/li/a"));

        private IWebElement ConsentButton => _driver.FindElement(By.XPath("/html/body/div[11]/div[2]/div[1]/div[2]/div[2]/button[1]/p"));

        public void clickAdvancedSearchButton()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var invisibleElement = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='fc-dialog-scrollable-content']")));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//body/table//ul/li/a")));
            clickableElement.Click();
        }

        public void clickConsentButton()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[11]/div[2]/div[1]/div[2]/div[2]/button[1]/p")));
            clickableElement.Click();
        }
    }
}
