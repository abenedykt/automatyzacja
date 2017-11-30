using PageObjectTests.Framework.Domain;
using System.Linq;

namespace PageObjectTests.Framework
{
    internal class NotePage
    {
        internal static void AddComment(Comment testData)
        {
            var commentBox = Browser.FindElementById("comment");
            commentBox.Click();
            commentBox.SendKeys(testData.Text);

            var emailLabel = Browser.FindByXpath("//label[@for='email']").First();
            emailLabel.Click();

            var email = Browser.FindElementById("email");
            email.SendKeys(testData.Mail + "@test.com"); // ;) just to make autotest example work - must not do like that :P


            var nameLabel = Browser.FindByXpath("//label[@for='author']").First();
            nameLabel.Click();

            var name = Browser.FindElementById("author");
            name.SendKeys(testData.User);

            var submit = Browser.FindElementById("comment-submit");
            submit.Click();
        }

        internal static bool ContainsComment(Comment exampleComment)
        {
            return Browser.PageContains(exampleComment.Text) 
                && Browser.PageContains(exampleComment.User);
        }
    }
}