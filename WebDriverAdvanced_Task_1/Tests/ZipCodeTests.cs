/*
 * Create a test with WebDriver which does the following:
 * Navigate to https://www.zip-codes.com/
 * Open Advanced Search and search for a town with the first 3 letters from your
 * name
 * Open the first 10 results from the list
 * For every one of them save City name, State, ZipCode, Longitude and Latitude
 * Generate a link to google maps by latitude and longitude for every one of the 10
 * results
 * Open each of the links in Google maps and take a screenshot of the page
 * Save each screenshot on the disk with file name
 * <CityName>-<State>-<ZipCode>.jpg, for example Paauilo- Hawaii- 96776.jpg
 * Think of an appropriate way to organize your tests and use Page Object Model
 * Base test class with methods missing in Selenium WebDriver
 */
//test
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.IO;
using WebDriverAdvanced_Task_1.Pages;

namespace WebDriverAdvanced_Task_1.Tests
{
    [TestClass]
    public class ZipCodeTests : BaseTest
    {
        [TestMethod]
        public void OpenAdvancedSearchAndSearchForTown()
        {
            HomePage homePage = new HomePage(_driver);
            SearchPage searchPage = new SearchPage(_driver);
            AdvancedSearchPage advancedSearchPage = new AdvancedSearchPage(_driver);

            homePage.clickSearchButton();
            searchPage.clickConsentButton();
            searchPage.clickAdvancedSearchButton();

            Assert.IsTrue(advancedSearchPage.isAdvancedSearchHeadingDisplayed());

            advancedSearchPage.searchForTown("Ale");

            Debug.WriteLine(_driver.Title);
            Assert.AreEqual<string>("Free Zip Code Finder and Lookup", _driver.Title);
        }

        string[] googleMapsUrls = new string[10];
        
        [TestMethod]
        public void OpenFirstTenResultsAndGenerateLinksToGoogleMaps()
        {
            HomePage homePage = new HomePage(_driver);
            SearchPage searchPage = new SearchPage(_driver);
            AdvancedSearchPage advancedSearchPage = new AdvancedSearchPage(_driver);
            SearchResultsPage searchResultsPage = new SearchResultsPage(_driver);
            ResultDetailsPage resultDetailsPage = new ResultDetailsPage(_driver);

            homePage.clickSearchButton();
            searchPage.clickConsentButton();
            searchPage.clickAdvancedSearchButton();

            Assert.IsTrue(advancedSearchPage.isAdvancedSearchHeadingDisplayed());

            advancedSearchPage.searchForTown("Ale");

            Debug.WriteLine(_driver.Title);
            Assert.AreEqual<string>("Free Zip Code Finder and Lookup", _driver.Title);

            string[] urls = searchResultsPage.getResultsUrls();
            for (int i = 0; i< 10; i++)
            {
                _driver.Navigate().GoToUrl(urls[i]);

                string city = resultDetailsPage.getCity();
                string state = resultDetailsPage.getState();
                string zipCode = resultDetailsPage.getZipCode();
                string longitude = resultDetailsPage.getLongitude();
                string latitude = resultDetailsPage.getLatitude();

                googleMapsUrls[i] = $"https://www.google.com/maps/place/{latitude}+{longitude}";

                Debug.WriteLine($"City: {city}, State: {state}, Zip Code: {zipCode}, Longitude: {longitude}, Latitude: {latitude}, Google Maps URL: {googleMapsUrls[i]}");
            }
        }

        [TestMethod]
        public void OpenGoogleMapLinksAndTakeAndSaveScreenshots()
        {
            HomePage homePage = new HomePage(_driver);
            SearchPage searchPage = new SearchPage(_driver);
            AdvancedSearchPage advancedSearchPage = new AdvancedSearchPage(_driver);
            SearchResultsPage searchResultsPage = new SearchResultsPage(_driver);
            ResultDetailsPage resultDetailsPage = new ResultDetailsPage(_driver);

            homePage.clickSearchButton();
            searchPage.clickConsentButton();
            searchPage.clickAdvancedSearchButton();

            Assert.IsTrue(advancedSearchPage.isAdvancedSearchHeadingDisplayed());

            advancedSearchPage.searchForTown("Ale");

            Debug.WriteLine(_driver.Title);
            Assert.AreEqual<string>("Free Zip Code Finder and Lookup", _driver.Title);

            string[] urls = searchResultsPage.getResultsUrls();
            for (int i = 0; i < 10; i++)
            {
                _driver.Navigate().GoToUrl(urls[i]);

                string city = resultDetailsPage.getCity();
                string state = resultDetailsPage.getState();
                string zipCode = resultDetailsPage.getZipCode();
                string longitude = resultDetailsPage.getLongitude();
                string latitude = resultDetailsPage.getLatitude();

                googleMapsUrls[i] = $"https://www.google.com/maps/place/{latitude}+{longitude}";

                Debug.WriteLine($"City: {city}, State: {state}, Zip Code: {zipCode}, Longitude: {longitude}, Latitude: {latitude}, Google Maps URL: {googleMapsUrls[i]}");

                _driver.Navigate().GoToUrl(googleMapsUrls[i]);

                GoogleMapsPage googleMapsPage = new GoogleMapsPage(_driver);
                if (i==0)
                {
                    googleMapsPage.waitToLoadAndClickAccept();
                }

                string filename = $"{city}-{state}-{zipCode}.{ScreenshotImageFormat.Png}";
                string fullPath = Path.Combine(Path.GetTempPath(), filename);
                Debug.WriteLine(fullPath);
                TakeFullScreenshot(_driver, fullPath);

                Assert.IsTrue(File.Exists(fullPath), "The screenshot map file was not found.");
            }
        }

        public void TakeFullScreenshot(IWebDriver driver, String filename)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(filename, ScreenshotImageFormat.Png); // .NET Core does not support image manipulation, so only Portable Network Graphics (PNG) format is supported
        }
    }
}
