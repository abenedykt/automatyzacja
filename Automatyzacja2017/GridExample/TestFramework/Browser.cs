using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace GridExample.TestFramework
{
    internal class Browser
    {
        private IWebDriver _driver;

        internal IWebElement FindElementById(string id)
        {
            return _driver.FindElement(By.Id(id));
        }

        internal string PageSource => _driver.PageSource;

        internal void WaitForInvisible(By by)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        internal ReadOnlyCollection<IWebElement> FindByXpath(string xpath)
        {
            return _driver.FindElements(By.XPath(xpath));
        }

        internal void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        internal bool PageContains(string text)
        {
            return _driver.FindElements(By.XPath($"//*[contains(text(), '{text}')]")).Any();
        }

        internal void Close()
        {
            _driver.Quit();
        }

        internal Browser()
        {
            var gridUrl = ConfigurationManager.AppSettings["selenium.grid.url"];
            if (string.IsNullOrEmpty(gridUrl))
            {
                CreateLocalBrowser();
            }
            else
            {
                UseGrid(gridUrl);
            }

            _driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(10);
        }

        private void UseGrid(string gridUrl)
        {
            var gridHubUrl = new Uri(gridUrl);
            var browser = ConfigurationManager.AppSettings["browser"];

            var capabilities = new DesiredCapabilities(browser, "", Platform.CurrentPlatform);

            _driver = new RemoteWebDriver(gridHubUrl, capabilities);
        }

        private void CreateLocalBrowser()
        {
            _driver = new ChromeDriver();
            _driver.Manage()
                .Window
                .Maximize();
        }

        public void InitElements(object page)
        {
            PageFactory.InitElements(_driver, page);
        }
    }
}