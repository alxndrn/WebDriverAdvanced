using OpenQA.Selenium;

namespace WebDriverAdvanced_Task_1.Pages
{
    class SearchResultsPage : BasePage
    {
        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement[] results = new IWebElement[10];

        public string[] getResultsUrls()
        {
            string[] resultsUrls = new string[10];
            for (int i = 0; i < 10; i++)
            {
                string resultXPath = "/html/body/table/tbody/tr/td[2]/div/table[1]/tbody/tr[" + (i+2) + "]/td[1]/a";
                results[i] = _driver.FindElement(By.XPath(resultXPath));

                resultsUrls[i] = results[i].GetAttribute("href");
            }
            return resultsUrls;
        }
    }
}
