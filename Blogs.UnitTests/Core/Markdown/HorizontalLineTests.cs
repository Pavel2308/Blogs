using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Core.Markdown;

namespace Blogs.UnitTests.Core.Markdown
{
    [TestClass()]
    public class HorizontalLineTests
    {
        HorizontalLine horizontalLine = new HorizontalLine();

        [TestMethod()]
        public void ToHtml_AsterisksAndSpaces_ReturnsHr()
        {
            string input = "* * *";
            string expected = "<hr />\n";
            horizontalLine.Set(input);
            string actual = horizontalLine.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_Asterisks_ReturnsHr()
        {
            string input = "***";
            string expected = "<hr />\n";
            horizontalLine.Set(input);
            string actual = horizontalLine.ToHtml();
            Assert.AreEqual(expected, actual);
        }
    }
}