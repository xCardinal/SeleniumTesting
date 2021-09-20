using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumPOMWalkthrough.lib.driver_config;

namespace SeleniumPOMWalkthrough.lib.pages
{
    public class AP_LastPage
    {
        private IWebDriver _seleniumDriver;

        private string _UserPageUrl = AppConfigReader.UserPageUrl;

        private IWebElement _shoppingCartButton => _seleniumDriver.FindElement(By.Id("shopping_cart_container"));
        private IWebElement _header => _seleniumDriver.FindElement(By.Id("header_container"));
        private IWebElement _backpack => _seleniumDriver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        //private IWebElement _itemsInCart => _seleniumDriver.FindElement(By.ClassName("shopping_cart_badge"));

        public AP_LastPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        public void GoToUserPage() => _seleniumDriver.Navigate().GoToUrl(_UserPageUrl);

        public void ClickShoppingCartButton() => _shoppingCartButton.Click();

        public string GetHeaderText() => _header.Text;

        public void AddBagToCart() => _backpack.Click();

        public int NumberOfItemsInCart()
        {
            //try
            //    { return Int32.Parse(_itemsInCart.Text); }
            //catch
            //{
            //    return 0;
            //}
            return Int32.Parse(_shoppingCartButton.Text);
        }
        


    }
}
