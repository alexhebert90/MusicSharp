using Xunit;

namespace MusicSharp.Tests
{
    public class NoteNamesTests
    {
        [Fact]
        public void VerifyNoteNames()
        {
            // As basic as this test is, it is here to make sure I don't make any incredibly dumb mistakes in the future.

            Assert.Equal("A", NoteNames.A);

            Assert.Equal("B", NoteNames.B);

            Assert.Equal("C", NoteNames.C);

            Assert.Equal("D", NoteNames.D);

            Assert.Equal("E", NoteNames.E);

            Assert.Equal("F", NoteNames.F);

            Assert.Equal("G", NoteNames.G);
        }
    }
}
