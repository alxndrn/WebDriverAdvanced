using OpenQA.Selenium;

namespace WebDriverAdvanced_Task_2.Pages
{
    public class MyAccountPage : BasePage
    {
        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement UsernameInput => _driver.FindElement(By.Id("username"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Name("login"));
        private IWebElement RecentOrdersLink => _driver.FindElement(By.XPath("//a[text()='recent orders']"));
        private IWebElement FirstOrderLink => _driver.FindElement(By.XPath("//a[@href='http://demos.bellatrix.solutions/my-account/view-order/786/']"));
        private IWebElement SecondOrderLink => _driver.FindElement(By.XPath("//a[@href='http://demos.bellatrix.solutions/my-account/view-order/788/']"));

        public void enterUsername(string username)
        {
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
        public void clickRecentOrdersLink()
        {
            RecentOrdersLink.Click();
        }
        public bool isFirstOrderLinkDisplayed()
        {
            return FirstOrderLink.Displayed;
        }
        public bool isSecondOrderLinkDisplayed()
        {
            return SecondOrderLink.Displayed;
        }
    }
}
