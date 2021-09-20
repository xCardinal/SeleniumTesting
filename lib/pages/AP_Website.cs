using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumPOMWalkthrough.lib.driver_config;

namespace SeleniumPOMWalkthrough.lib.pages
{
    //Super Class - - Essentially a service object for all pages
    public class AP_Website<T> where T : IWebDriver, new()
    {
        //Properties - Accessing POs and Selenium driver
        public IWebDriver SeleniumDriver { get; set; }
        public AP_HomePage AP_HomePage { get; set; }
        public AP_UserPage AP_UserPage { get; set; }
        
        //Constructor for driver and config for the service
        public AP_Website(int pageLoadInSecs = 10, int implicitWaitInSecs = 10)
        {
            //Instantiate the driver
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs).Driver;
            
            //Instantiate the PO with the selenium driver
            AP_HomePage = new AP_HomePage(SeleniumDriver);
            AP_UserPage = new AP_UserPage(SeleniumDriver);

        }
        //Delete cookies

        public void DeleteCookies() => SeleniumDriver.Manage().Cookies.DeleteAllCookies();


    }
}
