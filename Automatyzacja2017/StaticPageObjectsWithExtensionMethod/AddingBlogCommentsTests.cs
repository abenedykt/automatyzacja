using System;
using Ploeh.AutoFixture.Xunit2;
using StaticPageObjectsWithExtensionMethod.Domain;
using StaticPageObjectsWithExtensionMethod.TestFramework;
using Xunit;

namespace StaticPageObjectsWithExtensionMethod
{
    public class AddingBlogCommentsTests : IDisposable
    {
        private readonly Browser _;

        public AddingBlogCommentsTests()
        {
            _ = new Browser();
        }

        [Theory, AutoData]
        public void CanAddCommentToTheBlogNote(Comment exampleComment)
        {
            _.MainPageOpen();
            _.MainPageOpenFirstNote();
            _.NotePageAddComment(exampleComment);

            Assert.True(_.NotePageContainsComment(exampleComment));
        }

        public void Dispose()
        {
            _.Close();
        }
    }
}
