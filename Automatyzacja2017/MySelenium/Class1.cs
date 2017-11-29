using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;
using OpenQA.Selenium.Chrome;
using System.Linq;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace SeleniumTests
{
    public class SeleniumExample : IDisposable
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        public SeleniumExample()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts()
                .ImplicitWait = TimeSpan.FromMilliseconds(100);
            baseURL = "https://www.google.pl/";
            verificationErrors = new StringBuilder();
        }

        [Fact]
        public void NavigatingToCodeSprintersSite()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("lst-ib")).Clear();
            driver.FindElement(By.Id("lst-ib")).SendKeys("code sprinters");
            driver.FindElement(By.Id("lst-ib")).Submit();
            driver.FindElement(By.LinkText("Code Sprinters -")).Click();

            var element = driver.FindElement(By.LinkText("Poznaj nasze podejście"));
            Assert.NotNull(element);

            var elements = driver.FindElements(By.LinkText("Poznaj nasze podejście"));
            Assert.Single(elements);

            driver.FindElement(By.LinkText("Akceptuję")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(11));
            wait.Until(ExpectedConditions.InvisibilityOfElementWithText(By.LinkText("Akceptuję"), "Akceptuję"));

            WaitForClickable(By.LinkText("Poznaj nasze podejście"), 5);

            driver.FindElement(By.LinkText("Poznaj nasze podejście")).Click();

            // ver 1
            Assert.Contains("WIEDZA NA PIERWSZYM MIEJSCU", driver.PageSource);


            // ver 2
            Assert.Single(driver.FindElements(By.TagName("h2"))
                .Where(tag => tag.Text == "WIEDZA NA PIERWSZYM MIEJSCU"));


        }

        protected void WaitForClickable(By by, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected void waitForElementPresent(IWebElement by, int seconds)
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
