using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Markdown.Parsers.ElementParsers;

namespace Blogs.UnitTests.Markdown.Parsers.ElementParsers
{
    [TestClass()]
    public class CodeBlockTests
    {
        BaseElementParser codeBlock = new CodeBlockParser();
        [TestMethod()]
        public void Parse_SpacesAndTabes_ReturnsPreCode()
        {
            string input = "This is a normal paragraph:\n\n    This is a code block.";
            string expected = "<p>This is a normal paragraph:</p>\n\n<pre><code>This is a code block.\n</code></pre>";
            string actual = codeBlock.Parse(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Parse_AmpersandsAndAngleBrackets_ReturnsHtmlCode()
        {
            string input = "\n\n    <div class=\"footer\">\n        &copy; 2004 Foo Corporation\n    </div>";
            string expected = "<p></p>\n\n<pre><code>&lt;div class=\"footer\"&gt;\n    &amp;copy; 2004 Foo Corporation\n&lt;/div&gt;\n</code></pre>";
            string actual = codeBlock.Parse(input);
            Assert.AreEqual(expected, actual);
        }
    }
}