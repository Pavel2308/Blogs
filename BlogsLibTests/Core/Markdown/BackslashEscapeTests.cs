using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Core.Markdown;

namespace Blogs.UnitTests.Core.Markdown
{
    [TestClass()]
    public class BackslashEscapeTests
    {
        BackslashEscape backslashEscape = new BackslashEscape();
        [TestMethod()]
        public void ToHtml_LiteralAsterisks_ReturnsHtmlCode()
        {
            string input = @"\*";
            string expected = "&#42;";
            backslashEscape.Set(input);
            string actual = backslashEscape.ToHtml();
            Assert.AreEqual(expected, actual);
        }
    }
}