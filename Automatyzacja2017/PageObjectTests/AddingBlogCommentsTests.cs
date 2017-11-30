using OpenQA.Selenium;
using System;
using System.Threading;
using Xunit;

namespace PageObjectTests
{
    public class AddingBlogCommentsTests : IDisposable
    {
        [Fact]
        public void CanAddCommentToTheBlogNote()
        {
            MainPage.Open();
            MainPage.OpenFirstNote();
            NotePage.AddComment(new Comment
            {
                Text = "Lorem ipsum dolor sit",
                Mail = Guid.NewGuid() +  "@test.com",
                User = "białko"
            });
            // sprawdz ze komentarz się dodał
        }


        
        public void Dispose()
        {
            Browser.Close();
        }
    }
}
