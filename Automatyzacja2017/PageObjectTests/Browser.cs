using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace PageObjectTests
{
    internal class Browser
    {
        private static IWebDriver driver;

        internal static IWebElement FindElementById(string id)
        {
            return driver.FindElement(By.Id(id));
        }

        static Browser()
        {
            //            driver = new ChromeDriver();
            driver = new ChromeDriver();
            driver.Manage()
                .Window
                .Maximize();

            driver.Manage()
                .Timeouts()
                .ImplicitWait = TimeSpan.FromSeconds(10);
        }

        internal static string PageSource => driver.PageSource;

        internal static void WaitForInvisible(By by)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        internal static ReadOnlyCollection<IWebElement> FindByXpath(string xpath)
        {
            return driver.FindElements(By.XPath(xpath));
        }

        internal static void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        internal static bool PageContains(string text)
        {
            return driver.FindElements(By.XPath($"//*[contains(text(), '{text}')]")).Any();
        }

        internal static void Close()
        {
            driver.Quit();
        }
    }
}