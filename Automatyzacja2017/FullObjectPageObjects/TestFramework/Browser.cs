using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace FullObjectPageObjects.TestFramework
{
    internal class Browser
    {
        private IWebDriver driver;

        internal IWebElement FindElementById(string id)
        {
            return driver.FindElement(By.Id(id));
        }

        internal  string PageSource => driver.PageSource;

        internal  void WaitForInvisible(By by)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        internal  ReadOnlyCollection<IWebElement> FindByXpath(string xpath)
        {
            return driver.FindElements(By.XPath(xpath));
        }

        internal void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        internal bool PageContains(string text)
        {
            return driver.FindElements(By.XPath($"//*[contains(text(), '{text}')]")).Any();
        }

        internal void Close()
        {
            driver.Quit();
        }

        internal  Browser()
        {
            driver = new ChromeDriver();
            driver.Manage()
                .Window
                .Maximize();

            driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}