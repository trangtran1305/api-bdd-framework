using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;

namespace ProjectCore.GUICore.DriverProvider
{
    public class FirefoxDriverProvider: DriverProviderBase
    {
        protected DriverAddition driverAddition;
        public FirefoxDriverProvider(DriverAddition driverAddition)
        {
            this.driverAddition = driverAddition;
        }
        public override IWebDriver CreateDriver()
        {
            var firefoxOption = new FirefoxOptions();

            foreach(var argument in driverAddition.Arguments)
            {
                firefoxOption.AddArgument(argument.ArgumentName);
            }
            var driver = new FirefoxDriver(firefoxOption);            
            return driver;

        }
        public override void KillDriverService()
        {
            //TODO: Luy add kill service code here
            throw new NotImplementedException();
        }

    }
}
