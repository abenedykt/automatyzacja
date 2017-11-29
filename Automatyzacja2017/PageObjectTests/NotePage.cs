using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;

namespace PageObjectTests
{
    internal class NotePage
    {
        internal static void AddComment(Comment testData)
        {
            var commentBox = Browser.FindElementById("comment");
            commentBox.Click();
            commentBox.SendKeys(testData.Text);
            
            var nameLabel = Browser.FindByXpath("//label[@for='author']").First();
            nameLabel.Click();

            Thread.Sleep(2000);

            var name = Browser.FindElementById("author");
            name.Click();
            name.SendKeys(testData.User);

            var email = Browser.FindElementById("email");
            email.Click();
            email.SendKeys(testData.Mail);

            var submit = Browser.FindElementById("comment-submit");
            submit.Click();
        }
    }
}