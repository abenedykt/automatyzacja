using System;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using Xunit;

namespace PageObjectTests
{
    public class DebuggingWordpresAndSeleniumProblems
    {
        [Fact]
        public void Test()
        {
            var driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/2017/11/29/hello-world/");

            var text = driver.FindElementById("comment");
            text.Click();
            text.SendKeys("hello");

            var mailLabel = driver.FindElementByXPath("//label[@for='email']");
            mailLabel.Click();
            
            var mail = driver.FindElementById("email");

            mail.Click();
            mail.SendKeys(Guid.NewGuid() +  "@onet.pl");

            var name = driver.FindElementById("author");
            name.Click();
            name.SendKeys("test");

            driver.Quit();
        }

        [Fact]
        public void Test2()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://autotestdotnet.wordpress.com/2017/11/29/hello-world/");

            var text = driver.FindElementById("comment");
            text.Click();
            text.SendKeys("hello");

            var mailLabel = driver.FindElementByCssSelector(".comment-form-email > label");
            mailLabel.Click();

            Thread.Sleep(4000);
            var mail = driver.FindElementById("email");
            mail.Click();
            mail.SendKeys(Guid.NewGuid() + "@onet.pl");

            driver.Quit();
        }
    }
}
