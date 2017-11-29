using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Collections.ObjectModel;

namespace SeleniumTests
{
    public class SeleniumExample : IDisposable
    {
        private const string Google = "https://www.google.com";
        private const string SearchTextBoxId = "lst-ib";
        private const string PageTitle = "Code Sprinters -";
        private const string TextToSearch = "code sprinters";
        private const string CookiePolicyAcceptButton = "Akceptuję";
        private const string OurApproachText = "Poznaj nasze podejście";

        private IWebDriver driver;
        private StringBuilder verificationErrors;

        public SeleniumExample()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts()
            .ImplicitWait = TimeSpan.FromMilliseconds(100);
            verificationErrors = new StringBuilder();
        }

        [Fact]
        public void NavigatingToCodeSprintersSite()
        {
            GoToGoogle();
            Search(TextToSearch);
            GoToSearchResultByPageTitle(PageTitle);

            Assert.Single(GetElementsByLinkText(OurApproachText));

            GoToOurApproachPage();
            
            // ver 1
            Assert.Contains("WIEDZA NA PIERWSZYM MIEJSCU", driver.PageSource);

            // ver 2
            Assert.Single(driver.FindElements(By.TagName("h2"))
            .Where(tag => tag.Text == "WIEDZA NA PIERWSZYM MIEJSCU"));
        }

        private void GoToOurApproachPage()
        {
            AcceptCookiesPolicy();
            OpenOurAproachPage();
        }

        private void AcceptCookiesPolicy()
        {
            driver.FindElement(By.LinkText(CookiePolicyAcceptButton)).Click();

            const int MaxAnimationTime = 11;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(MaxAnimationTime));
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText(CookiePolicyAcceptButton), CookiePolicyAcceptButton));
        }

        private void OpenOurAproachPage()
        {
            By element = By.LinkText(OurApproachText);
            WaitForClickable(element, 5);

            driver.FindElement(element).Click();
        }

        private ReadOnlyCollection<IWebElement> GetElementsByLinkText(string linkTextToFind)
        {
            return driver.FindElements(By.LinkText(linkTextToFind));
        }

        private void Search(string query)
        {
            var searchBox = GetSearchBox();
            searchBox.Clear();
            searchBox.SendKeys(query);
            searchBox.Submit();
        }

        private void GoToSearchResultByPageTitle(string title)
        {
            driver.FindElement(By.LinkText(title)).Click();
        }

        private void GoToGoogle()
        {
            driver.Navigate().GoToUrl(Google);
        }

        private IWebElement GetSearchBox()
        {
            return driver.FindElement(By.Id(SearchTextBoxId));
        }

        private void WaitForClickable(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        private void waitForElementPresent(IWebElement by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        public void Dispose()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
            }
            Assert.Equal("", verificationErrors.ToString());
        }
    }
}
