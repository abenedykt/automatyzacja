using Ploeh.AutoFixture.Xunit2;
using System;
using Xunit;

namespace PageObjectTests
{
    public class AddingBlogCommentsTests : IDisposable
    {
        [Theory, AutoData]
        public void CanAddCommentToTheBlogNote(string text, string user)
        {

            var comment = new Comment
            {
                Text = text,
                Mail = Guid.NewGuid() + "@test.com",
                User = user
            };

            MainPage.Open();
            MainPage.OpenFirstNote();
            NotePage.AddComment(comment);

            Assert.Contains(comment.Text, Browser.PageSource);
        }


        
        public void Dispose()
        {
            Browser.Close();
        }
    }
}
