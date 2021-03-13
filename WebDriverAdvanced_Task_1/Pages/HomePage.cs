using OpenQA.Selenium;

namespace WebDriverAdvanced_Task_1.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement SearchButton => _driver.FindElement(By.XPath("//body//div[@class='pos']/a[text()='Search']"));

        public void clickSearchButton()
        {
            SearchButton.Click();
        }
    }
}
