using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectCore.GUICore.WebElementProvider
{
    public class Checkbox:Element
    {
        public Checkbox(By locator) : base(locator)
        {

        }
        public bool GetSelectedStatus()
        {
            return Find().Selected;
        }
        public void Click()
        {
            Find(_locator).Click();
            Thread.Sleep(1000);
        }
    }
}
