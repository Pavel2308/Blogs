using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Markdown.Parsers.ElementParsers;

namespace Blogs.UnitTests.Markdown.Parsers.ElementParsers
{
    [TestClass()]
    public class LinkTests
    {
        BaseElementParser link = new LinkParser();
        [TestMethod()]
        public void Parse_NotTitledLink_ReturnsHtmlLink()
        {
            string input = "[This link](http://example.net/) has no title attribute.\n";
            string expected = "<p><a href=\"http://example.net/\">This link</a> has no title attribute.</p>\n";
            string actual = link.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_TitledLink_ReturnsHtmlLink()
        {
            string input = "This is [an example](http://example.com/ \"Title\") inline link.\n";
            string expected = "<p>This is <a href=\"http://example.com/\" title=\"Title\">an example</a> inline link.</p>\n";
            string actual = link.Parse(input);
            Assert.AreEqual(expected, actual);
        }
    }
}