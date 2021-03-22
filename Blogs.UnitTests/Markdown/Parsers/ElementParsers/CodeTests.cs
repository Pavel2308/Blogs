using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Markdown.Parsers.ElementParsers;

namespace Blogs.UnitTests.Markdown.Parsers.ElementParsers
{
    [TestClass()]
    public class CodeTests
    {
        BaseElementParser code = new CodeParser();
        [TestMethod()]
        public void Parse_BacktickQuotes_ReturnsCode()
        {
            string input = "Use the `printf()` function.";
            string expected = "<p>Use the <code>printf()</code> function.</p>";
            string actual = code.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_DoubleBacktickQuotes_ReturnsCode()
        {
            string input = "``There is a literal backtick (`) here.``";
            string expected = "<p><code>There is a literal backtick (&grave;) here.</code></p>";
            string actual = code.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_AngleBrackets_ReturnsHtmlCode()
        {
            string input = "Please don't use any `<blink>` tags.";
            string expected = "<p>Please don't use any <code>&lt;blink&gt;</code> tags.</p>";
            string actual = code.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_Ampersands_ReturnsHtmlCode()
        {
            string input = "`&#8212;` is the decimal-encoded equivalent of `&mdash;`.";
            string expected = "<p><code>&amp;#8212;</code> is the decimal-encoded equivalent of <code>&amp;mdash;</code>.</p>";
            string actual = code.Parse(input);
            Assert.AreEqual(expected, actual);
        }
    }
}