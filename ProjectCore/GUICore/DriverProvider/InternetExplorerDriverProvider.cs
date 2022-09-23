using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.IO;

namespace ProjectCore.GUICore.DriverProvider
{
    public class InternetExplorerDriverProvider:DriverProviderBase
    {
        protected DriverAddition driverAddition;
        public InternetExplorerDriverProvider(DriverAddition driverAddition)
        {
            this.driverAddition = driverAddition;
        }
        public override IWebDriver CreateDriver()
        {            
            var driver = new InternetExplorerDriver();
            return driver;
        }
        public override void KillDriverService()
        {
            //TODO: Luy add kill service code here
            throw new NotImplementedException();
        }
    }
}
