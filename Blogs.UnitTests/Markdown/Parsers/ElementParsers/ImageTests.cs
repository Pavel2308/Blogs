using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Markdown.Parsers.ElementParsers;

namespace Blogs.UnitTests.Markdown.Parsers.ElementParsers
{
    [TestClass()]
    public class ImageTests
    {
        BaseElementParser image = new ImageParser();
        [TestMethod()]
        public void Parse_NotTitledLink_ReturnsImg()
        {
            string input = "![Alt text](/path/to/img.jpg)\n";
            string expected = "<p><img src=\"/path/to/img.jpg\" alt=\"Alt text\"></p>\n";
            string actual = image.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_TitledLink_ReturnsImg()
        {
            string input = "![Alt text](/path/to/img.jpg \"Optional title\")\n";
            string expected = "<p><img src=\"/path/to/img.jpg\" title=\"Optional title\" alt=\"Alt text\"></p>\n";
            string actual = image.Parse(input);
            Assert.AreEqual(expected, actual);
        }
    }
}