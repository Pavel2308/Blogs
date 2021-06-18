using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Core.Markdown;

namespace Blogs.UnitTests.Core.Markdown
{
    [TestClass()]
    public class LinkTests
    {
        Link link = new Link();
        [TestMethod()]
        public void ToHtml_NotTitledLink_ReturnsHtmlLink()
        {
            string input = "[This link](http://example.net/) has no title attribute.\n";
            string expected = "<p><a href=\"http://example.net/\">This link</a> has no title attribute.</p>\n";
            link.Set(input);
            string actual = link.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_TitledLink_ReturnsHtmlLink()
        {
            string input = "This is [an example](http://example.com/ \"Title\") inline link.\n";
            string expected = "<p>This is <a href=\"http://example.com/\" title=\"Title\">an example</a> inline link.</p>\n";
            link.Set(input);
            string actual = link.ToHtml();
            Assert.AreEqual(expected, actual);
        }
    }
}