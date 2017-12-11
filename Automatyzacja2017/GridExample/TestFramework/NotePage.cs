using GridExample.Domain;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GridExample.TestFramework
{
    internal class NotePage
    {
        private readonly Browser _browser;

        public NotePage(Browser browser)
        {
            _browser = browser;
            _browser.InitElements(this);
        }
        
        [FindsBy(How = How.Id, Using = "comment")]
        private IWebElement commentBox;

        [FindsBy(How = How.XPath, Using = "//label[@for='email']")]
        private IWebElement emailLabel;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement email;

        [FindsBy(How = How. XPath, Using = "//label[@for='author']")]
        private IWebElement nameLabel;

        [FindsBy(How = How.Id, Using = "author")]
        private IWebElement name;

        [FindsBy(How = How.Id, Using = "comment-submit")]
        private IWebElement submit;

        internal void AddComment(Comment testData)
        {
            commentBox.Click();
            commentBox.SendKeys(testData.Text);
            emailLabel.Click();
            email.SendKeys(testData.Mail + "@test.com"); // ;) just to make autotest example work - must not do like that :P
            nameLabel.Click();
            name.SendKeys(testData.User);
            submit.Click();
        }

        internal bool ContainsComment(Comment exampleComment)
        {
            return _browser.PageContains(exampleComment.Text) 
                && _browser.PageContains(exampleComment.User);
        }
    }
}