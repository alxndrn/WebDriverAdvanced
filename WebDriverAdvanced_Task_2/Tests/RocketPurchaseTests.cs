/*
 * Create 3 new tests, making a purchase of rockets from the online shop -
 * http://demos.bellatrix.solutions/
 * ● Create one test with a new client.
 * ● Create a second test with the already created client using the login form, prefilling
 * the billing info.
 * ● Create a third test verifying that the orders are present in the account section
 *      ○ Use the discount coupon - happybirthday. Verify that the coupon was applied
 *      successfully.
 *      ○ Increase the quantity to 3. Verify on all pages that all amounts are correct.
 *      ○ Think of a smart strategy to wait for async operations.
 *      ○ Design the tests to use page objects.
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDriverAdvanced_Task_2.Pages;

namespace WebDriverAdvanced_Task_2.Tests
{
    [TestClass]
    public class RocketPurchaseTests : BaseTest
    {
        [TestMethod]
        public void RocketPurchaseWithNewClient()
        {
            HomePage homePage = new HomePage(_driver);
            CartPage cartPage = new CartPage(_driver);
            CheckoutPage checkoutPage = new CheckoutPage(_driver);
            OrderReceivedPage orderReceivedPage = new OrderReceivedPage(_driver);

            homePage.clickProtonRocketAddToCartButton();
            homePage.clickProtonRocketViewCartButton();

            cartPage.clickProceedToCheckoutButton();

            checkoutPage.enterFirstName("FirstName");
            checkoutPage.enterLastName("LastName");
            checkoutPage.enterStreetAddress("Street Address 77");
            checkoutPage.enterCity("City");
            checkoutPage.enterPostcode("7777");
            checkoutPage.enterPhone("0888777777");
            checkoutPage.enterEmail("a.varbanova@catenate.com");

            checkoutPage.selectCreateAccountCheckbox();

            checkoutPage.clickPlaceOrderButton();

            Assert.IsTrue(orderReceivedPage.isOrderReceivedHeadingDisplayed());
        }

        [TestMethod]
        public void RocketPurchaseWithRegisteredClient()
        {
            HomePage homePage = new HomePage(_driver);
            CartPage cartPage = new CartPage(_driver);
            CheckoutPage checkoutPage = new CheckoutPage(_driver);
            OrderReceivedPage orderReceivedPage = new OrderReceivedPage(_driver);

            homePage.clickProtonRocketAddToCartButton();
            homePage.clickProtonRocketViewCartButton();

            cartPage.clickProceedToCheckoutButton();

            checkoutPage.clickHereToLogin();
            checkoutPage.enterUsername("a.varbanova@catenate.com");
            checkoutPage.enterPassword("ueT^Ybiinha4");
            checkoutPage.clickLoginButton();

            checkoutPage.clickPlaceOrderButton();

            Assert.IsTrue(orderReceivedPage.isOrderReceivedHeadingDisplayed());
        }

        [TestMethod]
        public void CheckIfOrdersAreDisplayedInMyAccount()
        {
            HomePage homePage = new HomePage(_driver);
            MyAccountPage myAccountPage = new MyAccountPage(_driver);

            homePage.clickMyAccountLink();

            myAccountPage.enterUsername("a.varbanova@catenate.com");
            myAccountPage.enterPassword("ueT^Ybiinha4");
            myAccountPage.clickLoginButton();

            myAccountPage.clickRecentOrdersLink();

            Assert.IsTrue(myAccountPage.isFirstOrderLinkDisplayed());
            Assert.IsTrue(myAccountPage.isSecondOrderLinkDisplayed());
        }

        [TestMethod]
        public void RocketPurchaseWithRegisteredUserUsingCouponAndChangingQuantity()
        {
            HomePage homePage = new HomePage(_driver);
            CartPage cartPage = new CartPage(_driver);
            CheckoutPage checkoutPage = new CheckoutPage(_driver);
            OrderReceivedPage orderReceivedPage = new OrderReceivedPage(_driver);

            homePage.clickFalcon9AddToCartButton();
            homePage.clickFalcon9ViewCartButton();

            cartPage.enterCouponCode("happybirthday");
            cartPage.clickApplyCouponButton();

            Assert.IsTrue(cartPage.isSuccessMessageDisplayed());

            cartPage.enterFalcon9Quantity("3");
            cartPage.clickUpdateCartButton();

            Assert.IsTrue(cartPage.isSuccessMessageDisplayed());

            cartPage.clickProceedToCheckoutButton();

            Assert.IsTrue(checkoutPage.isQuantity3Displayed());

            checkoutPage.clickHereToLogin();
            checkoutPage.enterUsername("a.varbanova@catenate.com");
            checkoutPage.enterPassword("ueT^Ybiinha4");
            checkoutPage.clickLoginButton();

            checkoutPage.clickPlaceOrderButton();

            Assert.IsTrue(orderReceivedPage.isOrderReceivedHeadingDisplayed());
            Assert.IsTrue(orderReceivedPage.isQuantity3Displayed());
        }
    }
}
