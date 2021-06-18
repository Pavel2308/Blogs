using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Core.Markdown;

namespace Blogs.UnitTests.Core.Markdown
{
    [TestClass()]
    public class ImageTests
    {
        Image image = new Image();
        [TestMethod()]
        public void ToHtml_NotTitledLink_ReturnsImg()
        {
            string input = "![Alt text](/path/to/img.jpg)\n";
            string expected = "<p><img src=\"/path/to/img.jpg\" alt=\"Alt text\"></p>\n";
            image.Set(input);
            string actual = image.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_TitledLink_ReturnsImg()
        {
            string input = "![Alt text](/path/to/img.jpg \"Optional title\")\n";
            string expected = "<p><img src=\"/path/to/img.jpg\" title=\"Optional title\" alt=\"Alt text\"></p>\n";
            image.Set(input);
            string actual = image.ToHtml();
            Assert.AreEqual(expected, actual);
        }
    }
}