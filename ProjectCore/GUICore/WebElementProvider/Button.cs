using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectCore.GUICore.WebElementProvider
{
    public class Button : Element
    {
        public IWebDriver _driver;
        public int _waitTimeSetting;
 
        public Button(By locator):base(locator)
        {                   
        }       
        public void Click()
        {            
            Find(_locator).Click();
            //Thread.Sleep(1000);
        }              
    }
}
