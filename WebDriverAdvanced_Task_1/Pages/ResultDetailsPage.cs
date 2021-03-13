using OpenQA.Selenium;

namespace WebDriverAdvanced_Task_1.Pages
{
    class ResultDetailsPage : BasePage
    {
        public ResultDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement CityLabel => _driver.FindElement(By.XPath("//table[@class='statTable']/tbody/tr/td[1]/span[text()='City:']/parent::td/following-sibling::td[1]/a"));
        private IWebElement StateLabel => _driver.FindElement(By.XPath("//table[@class='statTable']/tbody/tr/td[1]/span[text()='State:']/parent::td/following-sibling::td[1]/a"));
        private IWebElement ZipCodeLabel => _driver.FindElement(By.XPath("//table[@class='statTable']/tbody/tr/td[1]/span[text()='Zip Code:']/parent::td/following-sibling::td[1]"));
        private IWebElement LongitudeLabel => _driver.FindElement(By.XPath("//table[@class='statTable']/tbody/tr/td[1]/span[text()='Longitude:']/parent::td/following-sibling::td[1]"));
        private IWebElement LatitudeLabel => _driver.FindElement(By.XPath("//table[@class='statTable']/tbody/tr/td[1]/span[text()='Latitude:']/parent::td/following-sibling::td[1]"));

        public string getCity()
        {
            return CityLabel.Text;
        }

        public string getState()
        {
            return StateLabel.Text;
        }

        public string getZipCode()
        {
            return ZipCodeLabel.Text;
        }

        public string getLongitude()
        {
            return LongitudeLabel.Text;
        }

        public string getLatitude()
        {
            return LatitudeLabel.Text;
        }
    }
}
