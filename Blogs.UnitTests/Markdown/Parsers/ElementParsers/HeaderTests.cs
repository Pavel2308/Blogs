using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Markdown.Parsers.ElementParsers;

namespace Blogs.UnitTests.Markdown.Parsers.ElementParsers
{
    [TestClass()]
    public class HeaderTests
    {
        BaseElementParser header = new HeaderParser();
        [TestMethod()]
        public void Parse_SetextHeaders_EqualSigns_ReturnsH1()
        {
            string input = "This is an H1\n=============";
            string expected = "<h1>This is an H1</h1>";
            string actual = header.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_SetextHeaders_Dashes_ReturnsH2()
        {
            string input = "This is an H2\n-------------";
            string expected = "<h2>This is an H2</h2>";
            string actual = header.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_AtxHeaders_OneHash_ReturnsH1()
        {
            string input = "# This is an H1";
            string expected = "<h1>This is an H1</h1>";
            string actual = header.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_AtxHeaders_TwoHashes_ReturnsH2()
        {
            string input = "## This is an H2";
            string expected = "<h2>This is an H2</h2>";
            string actual = header.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_AtxHeaders_SixHashes_ReturnsH6()
        {
            string input = "###### This is an H6";
            string expected = "<h6>This is an H6</h6>";
            string actual = header.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_ClosedAtxHeaders_OneHash_ReturnsH1()
        {
            string input = "# This is an H1 #";
            string expected = "<h1>This is an H1</h1>";
            string actual = header.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_ClosedAtxHeaders_TwoHashes_ReturnsH2()
        {
            string input = "## This is an H2 ##";
            string expected = "<h2>This is an H2</h2>";
            string actual = header.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_ClosedAtxHeaders_OpeningThreeHashes_AndClosingSixHashes_ReturnsH3()
        {
            string input = "### This is an H3 ######";
            string expected = "<h3>This is an H3</h3>";
            string actual = header.Parse(input);
            Assert.AreEqual(expected, actual);
        }
    }
}