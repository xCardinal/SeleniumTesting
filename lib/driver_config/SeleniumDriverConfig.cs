using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumPOMWalkthrough.lib.driver_config
{
    public class SeleniumDriverConfig<T> where T : IWebDriver, new()
    {
        public IWebDriver Driver { get; set; }
        
        //Constructor which calls a method to set up the driver depending on the browser we want
        public SeleniumDriverConfig(int pageLoadInSeconds, int implicitWaitInSec)
        {
            Driver = new T();
            DriverSetUp(pageLoadInSeconds, implicitWaitInSec);
        }

        public void DriverSetUp(int pageLoadInSeconds, int implicitWaitInSec)
        {
            //This is the time the driver will wait for the page to load
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSeconds);
            
            //This is the time the driver waits for the element before the test fails
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSec);
        }

        public void SetHeadlessBrowser()
        {
            Driver = new ChromeDriver();
            
            var options = new ChromeOptions();
            
            options.AddArgument("headless");
        }
    }
}
