using System;
using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough.lib.pages;
using NUnit.Framework;
using System.Threading;

namespace SeleniumPOMWalkthrough.tests
{
    public class AP_LastPage_Tests
    {
        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();

        [Test]
        public void WhenImOnTheInventoryPage_WhenIClickTheBasketIcon_ThenIShouldBeAbleToViewMyCart()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.InputUserName("standard_user");
            AP_Website.AP_HomePage.InputUserPass("secret_sauce");
            AP_Website.AP_HomePage.ClickLoginButton();

            //int numberOfItemsInCart = AP_Website.AP_LastPage.NumberOfItemsInCart();
            //var result = AP_Website.AP_UserPage.GetHeaderText();
            //Assert.That(result, Does.Contain("YOUR CART"));

            AP_Website.AP_LastPage.AddBagToCart();
            //AP_Website.AP_UserPage.ClickShoppingCartButton();

            //Assert.That(AP_Website.AP_LastPage.NumberOfItemsInCart, Is.EqualTo(numberOfItemsInCart + 1));
            Assert.That(AP_Website.AP_LastPage.NumberOfItemsInCart, Is.EqualTo(1));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            //Quites the driver and closes ever associated window
            AP_Website.SeleniumDriver.Quit();

            //Realse unmanaged resources
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
