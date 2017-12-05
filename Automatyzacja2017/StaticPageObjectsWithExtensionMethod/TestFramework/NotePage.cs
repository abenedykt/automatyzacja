using System.Linq;
using StaticPageObjectsWithExtensionMethod.Domain;

namespace StaticPageObjectsWithExtensionMethod.TestFramework
{
    internal static class NotePage
    {
        internal static void NotePageAddComment(this Browser browser, Comment testData)
        {
            var commentBox = browser.FindElementById("comment");
            commentBox.Click();
            commentBox.SendKeys(testData.Text);

            var emailLabel = browser.FindByXpath("//label[@for='email']").First();
            emailLabel.Click();

            var email = browser.FindElementById("email");
            email.SendKeys(testData.Mail + "@test.com"); // ;) just to make autotest example work - must not do like that :P


            var nameLabel = browser.FindByXpath("//label[@for='author']").First();
            nameLabel.Click();

            var name = browser.FindElementById("author");
            name.SendKeys(testData.User);

            var submit = browser.FindElementById("comment-submit");
            submit.Click();
        }

        internal static bool NotePageContainsComment(this Browser browser, Comment exampleComment)
        {
            return browser.PageContains(exampleComment.Text) 
                && browser.PageContains(exampleComment.User);
        }
    }
}