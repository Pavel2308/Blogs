using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Core.Markdown;

namespace Blogs.UnitTests.Core.Markdown
{
    [TestClass()]
    public class UnorderedListTests
    {
        UnorderedList list = new UnorderedList();
        [TestMethod()]
        public void ToHtml_AsterisksList_ReturnsUnorderedList()
        {
            string input = "*   Red\n*   Green\n*   Blue\n";
            string expected = "<ul>\n<li>Red</li>\n<li>Green</li>\n<li>Blue</li>\n</ul>\n";
            list.Set(input);
            string actual = list.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_PlusesList_ReturnsUnorderedList()
        {
            string input = "+   Red\n+   Green\n+   Blue\n";
            string expected = "<ul>\n<li>Red</li>\n<li>Green</li>\n<li>Blue</li>\n</ul>\n";
            list.Set(input);
            string actual = list.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_HyphensList_ReturnsUnorderedList()
        {
            string input = "-   Red\n-   Green\n-   Blue\n";
            string expected = "<ul>\n<li>Red</li>\n<li>Green</li>\n<li>Blue</li>\n</ul>\n";
            list.Set(input);
            string actual = list.ToHtml();
            Assert.AreEqual(expected, actual);
        }
    }
}