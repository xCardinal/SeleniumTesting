using System;
using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough.lib.pages;
using NUnit.Framework;

namespace SeleniumPOMWalkthrough.tests
{
    public class AP_Signin_Tests
    {
        /*
         * Instantiate our pages in our tests
         * These classes will include the functions for the page.
         * 
         * Notice - NO USING STATEMENTS !
         * 
         */

        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();

        [Test]
        public void GivenIAmInTheHomePage_WhenISigninWithValidCredentials_ThenIShouldAppearInTheCustomerPortal()
        {
            //navigate to ap sign in page
            AP_Website.AP_HomePage.VisitHomePage();

            AP_Website.AP_HomePage.InputUserName("standard_user");
            AP_Website.AP_HomePage.InputUserPass("secret_sauce");

            AP_Website.AP_HomePage.ClickLoginButton();

            //Assert wether the title of the page is what we want
            Assert.That(AP_Website.SeleniumDriver.Url.Contains("inventory"));
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            //Quites the driver and closes ever associated window
            AP_Website.SeleniumDriver.Quit();

            //Realse unmanaged resources
            AP_Website.SeleniumDriver.Dispose();
        }
        #region SadPath
        [Test]
        public void GivenIAmInTheHomePage_WhenISigninWithInvalidCredentials_ThenSomething()
        {
            //navigate to ap sign in page
            AP_Website.AP_HomePage.VisitHomePage();

            AP_Website.AP_HomePage.InputUserName("standard_user");
            AP_Website.AP_HomePage.InputUserPass("1234");

            AP_Website.AP_HomePage.ClickLoginButton();

            //Assert wether the title of the page is what we want
            Assert.That(AP_Website.AP_HomePage.GetErrorMessage(), Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
        }

        [Test]
        public void GivenIAmInTheHomePage_WhenISigninWithNoUsernameAndNoPassword_ThenSomething()
        {
            //navigate to ap sign in page
            AP_Website.AP_HomePage.VisitHomePage();

            AP_Website.AP_HomePage.InputUserName(string.Empty);
            AP_Website.AP_HomePage.InputUserPass("1234");

            AP_Website.AP_HomePage.ClickLoginButton();

            //Assert wether the title of the page is what we want
            //Assert.That(AP_Website.SeleniumDriver.FindElement(By.CssSelector("*[data-test=\"error\"]")).Text, Is.EqualTo("Epic sadface: Username is required"));
            Assert.That(AP_Website.AP_HomePage.GetErrorMessage(), Is.EqualTo("Epic sadface: Username is required"));
        }
        [Test]
        public void GivenIAmInTheHomePage_WhenISigninWithUserButNoPassword_ThenSomething()
        {
            //navigate to ap sign in page
            AP_Website.AP_HomePage.VisitHomePage();

            AP_Website.AP_HomePage.InputUserName("standard_user");
            AP_Website.AP_HomePage.InputUserPass(string.Empty);

            AP_Website.AP_HomePage.ClickLoginButton();

            //Assert wether the title of the page is what we want
            Assert.That(AP_Website.AP_HomePage.GetErrorMessage(), Is.EqualTo("Epic sadface: Password is required"));
        }
        #endregion
    }
}
