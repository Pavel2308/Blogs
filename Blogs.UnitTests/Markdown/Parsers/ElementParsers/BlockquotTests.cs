using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Markdown.Parsers.ElementParsers;

namespace Blogs.UnitTests.Markdown.Parsers.ElementParsers
{
    [TestClass()]
    public class BlockquotTests
    {
        BaseElementParser blockquot = new BlockquotParser();
        [TestMethod()]
        public void Parse_AngleBracketsBeforeEveryLine_ReturnsBlockquot()
        {
            string input = "> This is a blockquote with two paragraphs. Lorem ipsum dolor sit amet,\n> consectetuer adipiscing elit. Aliquam hendrerit mi posuere lectus.\n> Vestibulum enim wisi, viverra nec, fringilla in, laoreet vitae, risus.\n> \n> Donec sit amet nisl. Aliquam semper ipsum sit amet velit. Suspendisse\n> id sem consectetuer libero luctus adipiscing.";
            string expected = "<blockquote>This is a blockquote with two paragraphs. Lorem ipsum dolor sit amet,\nconsectetuer adipiscing elit. Aliquam hendrerit mi posuere lectus.\nVestibulum enim wisi, viverra nec, fringilla in, laoreet vitae, risus.\n\nDonec sit amet nisl. Aliquam semper ipsum sit amet velit. Suspendisse\nid sem consectetuer libero luctus adipiscing.</blockquote>";
            string actual = blockquot.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_AngleBracketsOnlyBeforeParagraph_ReturnsBlockquot()
        {
            string input = "> This is a blockquote with two paragraphs. Lorem ipsum dolor sit amet,\nconsectetuer adipiscing elit. Aliquam hendrerit mi posuere lectus.\nVestibulum enim wisi, viverra nec, fringilla in, laoreet vitae, risus.\n\n> Donec sit amet nisl. Aliquam semper ipsum sit amet velit. Suspendisse\nid sem consectetuer libero luctus adipiscing.";
            string expected = "<blockquote>This is a blockquote with two paragraphs. Lorem ipsum dolor sit amet,\nconsectetuer adipiscing elit. Aliquam hendrerit mi posuere lectus.\nVestibulum enim wisi, viverra nec, fringilla in, laoreet vitae, risus.\n\nDonec sit amet nisl. Aliquam semper ipsum sit amet velit. Suspendisse\nid sem consectetuer libero luctus adipiscing.</blockquote>";
            string actual = blockquot.Parse(input);
            Assert.AreEqual(expected, actual);
        }
    }
}