using OpenQA.Selenium;

namespace WebDriverAdvanced_Task_1.Pages
{
    class AdvancedSearchPage : BasePage
    {
        public AdvancedSearchPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement AdvancedSearchHeading => _driver.FindElement(By.XPath("//body//h4[text()='Find ZIP Codes by City, State, Address, or Area Code']"));

        private IWebElement TownInput => _driver.FindElement(By.XPath("//label[text()='Town/City:']/following-sibling::input"));

        private IWebElement FindZIPCodesButton => _driver.FindElement(By.XPath("//*[@id='ui-id-8']/form/input[6]"));

        public bool isAdvancedSearchHeadingDisplayed()
        {
            if (AdvancedSearchHeading.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void searchForTown(string town)
        {
            TownInput.SendKeys(town);
            FindZIPCodesButton.Click();
        }
    }
}
