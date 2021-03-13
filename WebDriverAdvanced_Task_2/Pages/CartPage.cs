using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace WebDriverAdvanced_Task_2.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement CouponCodeInput => _driver.FindElement(By.Id("coupon_code"));
        private IWebElement ApplyCouponButton => _driver.FindElement(By.Name("apply_coupon"));
        private IWebElement Falcon9QuantityInput => _driver.FindElement(By.XPath("//input[@type='number']"));
        private IWebElement UpdateCartButton => _driver.FindElement(By.Name("update_cart"));

        public void clickProceedToCheckoutButton()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var proceedToCheckoutButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='post-6']/div/div/div[2]/div/div/a")));

            Actions actions = new Actions(_driver);
            actions.MoveToElement(proceedToCheckoutButton);
            actions.Perform();

            proceedToCheckoutButton.Click();
        }
        public void enterCouponCode(string couponCode)
        {
            CouponCodeInput.SendKeys(couponCode);
        }
        public void clickApplyCouponButton()
        {
            ApplyCouponButton.Click();
        }
        public bool isSuccessMessageDisplayed()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var successMessageMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='woocommerce-message']")));
            return successMessageMessage.Displayed;
        }
        public void enterFalcon9Quantity(string quantity)
        {
            Falcon9QuantityInput.Clear();
            Falcon9QuantityInput.SendKeys(quantity);
        }
        public void clickUpdateCartButton()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.StalenessOf(UpdateCartButton));
            UpdateCartButton.Click();
        }
    }
}
