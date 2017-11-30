using PageObjectTests.Framework;
using PageObjectTests.Framework.Domain;
using Ploeh.AutoFixture.Xunit2;
using System;
using Xunit;

namespace PageObjectTests
{
    public class AddingBlogCommentsTests : IDisposable
    {
        public AddingBlogCommentsTests()
        {
            Browser.Initialize();
        }

        [Theory, AutoData]
        public void CanAddCommentToTheBlogNote(Comment exampleComment)
        {
            MainPage.Open();
            MainPage.OpenFirstNote();
            NotePage.AddComment(exampleComment);

            Assert.True(NotePage.ContainsComment(exampleComment));
        }

        public void Dispose()
        {
            Browser.Close();
        }
    }
}
