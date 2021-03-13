using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace WebDriverAdvanced_Task_2.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement ProtonRocketAddToCartButton => _driver.FindElement(By.XPath("//*[@id='main']/div[2]/ul/li[2]/a[2]"));
        private IWebElement Falcon9AddToCartButton => _driver.FindElement(By.XPath("//*[@id='main']/div[2]/ul/li[1]/a[2]"));
        private IWebElement MyAccountLink => _driver.FindElement(By.XPath("//*[@id='site-navigation']/div[1]/ul/li[5]/a"));

        public void clickProtonRocketAddToCartButton()
        {
            ProtonRocketAddToCartButton.Click();
        }
        public void clickFalcon9AddToCartButton()
        {
            Falcon9AddToCartButton.Click();
        }
        public void clickProtonRocketViewCartButton()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var ProtonRocketViewCartButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='main']/div[2]/ul/li[2]/a[3]")));
            ProtonRocketViewCartButton.Click();
        }
        public void clickFalcon9ViewCartButton()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var Falcon9ViewCartButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='main']/div[2]/ul/li[1]/a[3]")));
            Falcon9ViewCartButton.Click();
        }
        public void clickMyAccountLink()
        {
            MyAccountLink.Click();
        }
    }
}
