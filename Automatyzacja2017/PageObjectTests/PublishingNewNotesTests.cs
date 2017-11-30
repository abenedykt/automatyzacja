using PageObjectTests.Framework;
using PageObjectTests.Framework.Domain;
using Ploeh.AutoFixture.Xunit2;
using System;
using Xunit;

namespace PageObjectTests
{
    public class PublishingNewNotesTests : IDisposable
    {
        public PublishingNewNotesTests()
        {
            Browser.Initialize();
        }

        [Theory, AutoData]
        public void CanAddNewNote(Note exampleNote)
        {
            // goto admin page
            // login
            // goto new note
            // create note
            // verify note exist
        }

        public void Dispose()
        {
            Browser.Close();
        }
    }
}
