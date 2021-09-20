using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumPOMWalkthrough.lib.pages
{
    public class AP_HomePage
    {
        #region Properties

        private IWebDriver _seleniumDriver;
        
        //Set the homepage url
        private string homePageUrl = AppConfigReader.BaseUrl;
        
        //Create a private property that models the sign in link
        private IWebElement _logInButton => _seleniumDriver.FindElement(By.Id("login-button"));

        #endregion

        // private IWebElement _signInLink
        // {
        //     get { return _seleniumDriver.FindElement(By.LinkText("Sign in")); }
        // }

        public IWebElement _loginButton => _seleniumDriver.FindElement(By.Id("login-button"));
        public IWebElement _passwordField => _seleniumDriver.FindElement(By.Id("password"));
        public IWebElement _usernameField => _seleniumDriver.FindElement(By.Id("user-name"));
        //public IWebElement _errorMessage => _seleniumDriver.FindElement(By.CssSelector("*[data-test=\"error\"]"));
        public IWebElement _errorMessage => _seleniumDriver.FindElement(By.Id("login_button_container"));

        //Constructor that sets the driver to be the driver from the config
        // public AP_HomePage(IWebDriver seleniumDriver)
        // {
        //     _seleniumDriver = seleniumDriver;
        // }
        public AP_HomePage(IWebDriver seleniumDriver) => _seleniumDriver = seleniumDriver;
        
        //Methods to interact with the web element
        public void VisitHomePage() => _seleniumDriver.Navigate().GoToUrl(homePageUrl);

        public void ClickLoginButton() => _logInButton.Click();

        public void InputUserName(string username) => _usernameField.SendKeys(username);
        public void InputUserPass(string password) => _passwordField.SendKeys(password);

        public string GetErrorMessage()
        {
            return _errorMessage.Text;
        }

    }
}
