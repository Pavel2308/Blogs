using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Markdown.Parsers.ElementParsers;

namespace Blogs.UnitTests.Markdown.Parsers.ElementParsers
{
    [TestClass()]
    public class HorizontalLineTests
    {
        BaseElementParser horizontalLine = new HorizontalLineParser();

        [TestMethod()]
        public void Parse_AsterisksAndSpaces_ReturnsHr()
        {
            string input = "* * *";
            string expected = "<hr />\n";
            string actual = horizontalLine.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_Asterisks_ReturnsHr()
        {
            string input = "***";
            string expected = "<hr />\n";
            string actual = horizontalLine.Parse(input);
            Assert.AreEqual(expected, actual);
        }
    }
}