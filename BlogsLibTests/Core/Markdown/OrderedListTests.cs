using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Core.Markdown;

namespace Blogs.UnitTests.Core.Markdown
{
    [TestClass()]
    public class OrderedListTests
    {
        OrderedList list = new OrderedList();
        [TestMethod()]
        public void ToHtml_GradualList_ReturnsOrderedList()
        {
            string input = "1.  Bird\n2.  McHale\n3.  Parish\n";
            string expected = "<ol>\n<li>Bird</li>\n<li>McHale</li>\n<li>Parish</li>\n</ol>\n";
            list.Set(input);
            string actual = list.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_NotGradualList_ReturnsOrderedList()
        {
            string input = "1.  Bird\n1.  McHale\n1.  Parish\n";
            string expected = "<ol>\n<li>Bird</li>\n<li>McHale</li>\n<li>Parish</li>\n</ol>\n";
            list.Set(input);
            string actual = list.ToHtml();
            Assert.AreEqual(expected, actual);
        }
    }
}