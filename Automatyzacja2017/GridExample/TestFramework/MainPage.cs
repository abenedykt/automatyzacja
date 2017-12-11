using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GridExample.TestFramework
{
    internal class MainPage
    {
        private const string Url = "http://autotestdotnet.wordpress.com/";
        private readonly Browser _browser;

        public MainPage(Browser browser)
        {
            _browser = browser;
        }

        internal void Open()
        {
            _browser.NavigateTo(Url);
            _browser.InitElements(this);
        }
        
        // wywołanie InitElements wypełni wszystkie zmienne z atrybutami FindsBy 
        [FindsBy(How = How.XPath, Using = "//article/header")]
        private IList<IWebElement> _articleHeaders;

        internal NotePage OpenFirstNote()
        {
            _articleHeaders.First().Click();
            return new NotePage(_browser);
        }
    }
}