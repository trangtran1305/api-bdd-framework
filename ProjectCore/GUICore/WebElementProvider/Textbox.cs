using OpenQA.Selenium;
using ProjectCore.GUICore.WebElementProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjectCore.GUICore.WebElementProvider
{
    public class Textbox:Element
    {
        public IWebDriver _driver;
        public int _waitTimeSetting;

        public Textbox(By locator) : base(locator)
        {
        }      
        public void Input(string text)
        {
            Find(_locator).SendKeys(text);
        }

        public void Click()
        {
            Find(_locator).Click();
        }

        public void Clear()
        {
            Find(_locator).SendKeys(Keys.Control + "a");
            Find(_locator).SendKeys(Keys.Backspace);
            //Thread.Sleep(500);
        }
        public void EditInput(string text)
        {
            //Find(_locator).Clear();
            Find(_locator).SendKeys(Keys.Control + "A");
            Find(_locator).SendKeys(Keys.Backspace);
            //Thread.Sleep(500);
            Find(_locator).SendKeys(text);
        }

        public void EditInput2(string text)
        {
            Find(_locator).Clear();
            Find(_locator).Clear();
            Find(_locator).SendKeys(text);
        }
    }
}
