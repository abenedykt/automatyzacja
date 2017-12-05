using System;
using FullObjectPageObjects.Domain;
using FullObjectPageObjects.TestFramework;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace FullObjectPageObjects
{
    public class AddingBlogCommentsTests : IDisposable
    {
        private readonly Browser _browser;
        private readonly MainPage _mainPage;

        public AddingBlogCommentsTests()
        {
            _browser = new Browser();
            _mainPage = new MainPage(_browser);
        }

        [Theory, AutoData]
        public void CanAddCommentToTheBlogNote(Comment exampleComment)
        {
            _mainPage.Open();
            var firstNote = _mainPage.OpenFirstNote();

            firstNote.AddComment(exampleComment);

            Assert.True(firstNote.ContainsComment(exampleComment));
        }

        public void Dispose()
        {
            _browser.Close();
        }
    }
}
