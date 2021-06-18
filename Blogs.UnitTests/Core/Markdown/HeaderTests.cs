using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Core.Markdown;

namespace Blogs.UnitTests.Core.Markdown
{
    [TestClass()]
    public class HeaderTests
    {
        Header header = new Header();
        [TestMethod()]
        public void ToHtml_SetextHeaders_EqualSigns_ReturnsH1()
        {
            string input = "This is an H1\n=============";
            string expected = "<h1>This is an H1</h1>";
            header.Set(input);
            string actual = header.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_SetextHeaders_Dashes_ReturnsH2()
        {
            string input = "This is an H2\n-------------";
            string expected = "<h2>This is an H2</h2>";
            header.Set(input);
            string actual = header.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_AtxHeaders_OneHash_ReturnsH1()
        {
            string input = "# This is an H1";
            string expected = "<h1>This is an H1</h1>";
            header.Set(input);
            string actual = header.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_AtxHeaders_TwoHashes_ReturnsH2()
        {
            string input = "## This is an H2";
            string expected = "<h2>This is an H2</h2>";
            header.Set(input);
            string actual = header.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_AtxHeaders_SixHashes_ReturnsH6()
        {
            string input = "###### This is an H6";
            string expected = "<h6>This is an H6</h6>";
            header.Set(input);
            string actual = header.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_ClosedAtxHeaders_OneHash_ReturnsH1()
        {
            string input = "# This is an H1 #";
            string expected = "<h1>This is an H1</h1>";
            header.Set(input);
            string actual = header.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_ClosedAtxHeaders_TwoHashes_ReturnsH2()
        {
            string input = "## This is an H2 ##";
            string expected = "<h2>This is an H2</h2>";
            header.Set(input);
            string actual = header.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_ClosedAtxHeaders_OpeningThreeHashes_AndClosingSixHashes_ReturnsH3()
        {
            string input = "### This is an H3 ######";
            string expected = "<h3>This is an H3</h3>";
            header.Set(input);
            string actual = header.ToHtml();
            Assert.AreEqual(expected, actual);
        }
    }
}