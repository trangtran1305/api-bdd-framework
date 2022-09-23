
using OpenQA.Selenium;

namespace ProjectCore.GUICore.DriverProvider
{
    public abstract class DriverProviderBase
    {
        private IWebDriver driver;


        public IWebDriver GetDriver()
        {
            return CreateDriver();
        }

        public abstract IWebDriver CreateDriver();
        public abstract void KillDriverService();


        public void DriverExist()
        {
            driver.Quit();
            driver = null;
        }        

    }
}
