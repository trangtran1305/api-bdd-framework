using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectCore.GUICore.WebElementProvider
{
    public class Label:Element
    {
        public Label (By locator) : base(locator)
        {

        }
        public string GetTextByLocator()
        {
            return Find().Text;
        }

        public string ValueWithOutWait()
        {            
            var webElement = Find();
            return JavaScriptActions.JsValue(webElement);
        }

        public void Click()
        {
            Find(_locator).Click();
            Thread.Sleep(1000);
        }
    }
}
