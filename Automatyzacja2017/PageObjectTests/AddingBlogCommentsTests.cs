using System;
using Xunit;

namespace PageObjectTests
{
    public class AddingBlogCommentsTests : IDisposable
    {
        [Fact]
        public void CanAddCommentToTheBlogNote()
        {
            MainPage.Open();

            // wejdz na strone bloga
            // otworz pierwsza notke
            // dodaj komentarz
            // sprawdz ze komentarz się dodał
        }

        public void Dispose()
        {
            Browser.Close();
        }
    }
}
