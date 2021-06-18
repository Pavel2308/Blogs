using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Core.Markdown;

namespace Blogs.UnitTests.Core.Markdown
{
    [TestClass()]
    public class BlockquotTests
    {
        Blockquot blockquot = new Blockquot();
        [TestMethod()]
        public void ToHtml_AngleBracketsBeforeEveryLine_ReturnsBlockquot()
        {
            string input = "> This is a blockquote with two paragraphs. Lorem ipsum dolor sit amet,\n> consectetuer adipiscing elit. Aliquam hendrerit mi posuere lectus.\n> Vestibulum enim wisi, viverra nec, fringilla in, laoreet vitae, risus.\n> \n> Donec sit amet nisl. Aliquam semper ipsum sit amet velit. Suspendisse\n> id sem consectetuer libero luctus adipiscing.";
            string expected = "<blockquote>This is a blockquote with two paragraphs. Lorem ipsum dolor sit amet,\nconsectetuer adipiscing elit. Aliquam hendrerit mi posuere lectus.\nVestibulum enim wisi, viverra nec, fringilla in, laoreet vitae, risus.\n\nDonec sit amet nisl. Aliquam semper ipsum sit amet velit. Suspendisse\nid sem consectetuer libero luctus adipiscing.\n\n</blockquote>";
            blockquot.Set(input);
            string actual = blockquot.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_AngleBracketsOnlyBeforeParagraph_ReturnsBlockquot()
        {
            string input = "> This is a blockquote with two paragraphs. Lorem ipsum dolor sit amet,\nconsectetuer adipiscing elit. Aliquam hendrerit mi posuere lectus.\nVestibulum enim wisi, viverra nec, fringilla in, laoreet vitae, risus.\n\n> Donec sit amet nisl. Aliquam semper ipsum sit amet velit. Suspendisse\nid sem consectetuer libero luctus adipiscing.";
            string expected = "<blockquote>This is a blockquote with two paragraphs. Lorem ipsum dolor sit amet,\nconsectetuer adipiscing elit. Aliquam hendrerit mi posuere lectus.\nVestibulum enim wisi, viverra nec, fringilla in, laoreet vitae, risus.\n\nDonec sit amet nisl. Aliquam semper ipsum sit amet velit. Suspendisse\nid sem consectetuer libero luctus adipiscing.\n\n</blockquote>";
            blockquot.Set(input);
            string actual = blockquot.ToHtml();
            Assert.AreEqual(expected, actual);
        }
    }
}