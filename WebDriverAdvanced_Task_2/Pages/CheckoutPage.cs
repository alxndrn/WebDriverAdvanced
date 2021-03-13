using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace WebDriverAdvanced_Task_2.Pages
{
    public class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement FirstNameInput => _driver.FindElement(By.Id("billing_first_name"));
        private IWebElement LastNameInput => _driver.FindElement(By.Id("billing_last_name"));
        private IWebElement StreetAddressInput => _driver.FindElement(By.Id("billing_address_1"));
        private IWebElement CityInput => _driver.FindElement(By.Id("billing_city"));
        private IWebElement PostcodeInput => _driver.FindElement(By.Id("billing_postcode"));
        private IWebElement PhoneInput => _driver.FindElement(By.Id("billing_phone"));
        private IWebElement EmailInput => _driver.FindElement(By.Id("billing_email"));
        private IWebElement CreateAccountCheckbox => _driver.FindElement(By.Id("createaccount"));
        private IWebElement PlaceOrderButton => _driver.FindElement(By.Id("place_order"));
        private IWebElement ClickHereToLoginLink => _driver.FindElement(By.XPath("//a[text()='Click here to login']"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Name("login"));

        public void enterFirstName(string firstName)
        {
            FirstNameInput.SendKeys(firstName);
        }
        public void enterLastName(string lastName)
        {
            LastNameInput.SendKeys(lastName);
        }
        public void enterStreetAddress(string streetAddress)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(StreetAddressInput);
            actions.Perform();

            StreetAddressInput.SendKeys(streetAddress);
        }
        public void enterCity(string city)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(CityInput);
            actions.Perform();

            CityInput.SendKeys(city);
        }
        public void enterPostcode(string postcode)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(PostcodeInput);
            actions.Perform(); 
            
            PostcodeInput.SendKeys(postcode);
        }
        public void enterPhone(string phone)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(PhoneInput);
            actions.Perform();

            PhoneInput.SendKeys(phone);
        }
        public void enterEmail(string email)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(EmailInput);
            actions.Perform();

            EmailInput.SendKeys(email);
        }
        public void selectCreateAccountCheckbox()
        {
            CreateAccountCheckbox.Click();
        }
        public void clickPlaceOrderButton()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            wait.Until(ExpectedConditions.StalenessOf(PlaceOrderButton));
            PlaceOrderButton.Click();
        }
        public void clickHereToLogin()
        {
            ClickHereToLoginLink.Click();
        }
        public void enterUsername(string username)
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var UsernameInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("username")));
            UsernameInput.SendKeys(username);
        }
        public void enterPassword(string password)
        {
            PasswordInput.SendKeys(password);
        }
        public void clickLoginButton()
        {
            LoginButton.Click();
        }
        public bool isQuantity3Displayed()
        {
            var wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 30));
            var quantity3Label = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//strong[contains(text(),'3')]")));
            return quantity3Label.Displayed;
        }
    }
}
