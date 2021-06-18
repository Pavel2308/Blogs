using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs.Core.Markdown;

namespace Blogs.UnitTests.Core.Markdown
{
    [TestClass()]
    public class CodeBlockTests
    {
        CodeBlock codeBlock = new CodeBlock();
        [TestMethod()]
        public void ToHtml_SpacesAndTabes_ReturnsPreCode()
        {
            string input = "This is a normal paragraph:\n\n    This is a code block.";
            string expected = "<p>This is a normal paragraph:</p>\n\n<pre><code>This is a code block.\n</code></pre>";
            codeBlock.Set(input);
            string actual = codeBlock.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_AmpersandsAndAngleBrackets_ReturnsHtmlCode()
        {
            string input = "\n\n    <div class=\"footer\">\n        &copy; 2004 Foo Corporation\n    </div>";
            string expected = "<p></p>\n\n<pre><code>&lt;div class=\"footer\"&gt;\n    &amp;copy; 2004 Foo Corporation\n&lt;/div&gt;\n</code></pre>";
            codeBlock.Set(input);
            string actual = codeBlock.ToHtml();
            Assert.AreEqual(expected, actual);
        }
    }
}