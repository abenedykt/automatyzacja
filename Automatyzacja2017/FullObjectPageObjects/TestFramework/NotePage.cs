using System.Linq;
using FullObjectPageObjects.Domain;

namespace FullObjectPageObjects.TestFramework
{
    internal class NotePage
    {
        private readonly Browser _browser;

        public NotePage(Browser browser)
        {
            _browser = browser;
        }

        internal void AddComment(Comment testData)
        {
            var commentBox = _browser.FindElementById("comment");
            commentBox.Click();
            commentBox.SendKeys(testData.Text);

            var emailLabel = _browser.FindByXpath("//label[@for='email']").First();
            emailLabel.Click();

            var email = _browser.FindElementById("email");
            email.SendKeys(testData.Mail + "@test.com"); // ;) just to make autotest example work - must not do like that :P


            var nameLabel = _browser.FindByXpath("//label[@for='author']").First();
            nameLabel.Click();

            var name = _browser.FindElementById("author");
            name.SendKeys(testData.User);

            var submit = _browser.FindElementById("comment-submit");
            submit.Click();
        }

        internal bool ContainsComment(Comment exampleComment)
        {
            return _browser.PageContains(exampleComment.Text) 
                && _browser.PageContains(exampleComment.User);
        }
    }
}