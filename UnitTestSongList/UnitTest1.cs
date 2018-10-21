using Microsoft.VisualStudio.TestTools.UnitTesting;
using SongList;
using System.Windows;

namespace UnitTestSongList
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SongList.Form1 form1 = new Form1();
            form1.ArtistSearch("metallica");
        }
        public void TestMethod2()
        {
            SongList.Form1 form1 = new Form1();
            form1.ArtistSearch("metallica ");
        }
    }
}
