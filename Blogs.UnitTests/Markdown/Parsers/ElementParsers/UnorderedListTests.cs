using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Markdown.Parsers.ElementParsers;

namespace Blogs.UnitTests.Markdown.Parsers.ElementParsers
{
    [TestClass()]
    public class UnorderedListTests
    {
        BaseElementParser list = new UnorderedListParser();
        [TestMethod()]
        public void Parse_AsterisksList_ReturnsUnorderedList()
        {
            string input = "*   Red\n*   Green\n*   Blue\n";
            string expected = "<ul>\n<li>Red</li>\n<li>Green</li>\n<li>Blue</li>\n</ul>\n";
            string actual = list.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_PlusesList_ReturnsUnorderedList()
        {
            string input = "+   Red\n+   Green\n+   Blue\n";
            string expected = "<ul>\n<li>Red</li>\n<li>Green</li>\n<li>Blue</li>\n</ul>\n";
            string actual = list.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_HyphensList_ReturnsUnorderedList()
        {
            string input = "-   Red\n-   Green\n-   Blue\n";
            string expected = "<ul>\n<li>Red</li>\n<li>Green</li>\n<li>Blue</li>\n</ul>\n";
            string actual = list.Parse(input);
            Assert.AreEqual(expected, actual);
        }
    }
}