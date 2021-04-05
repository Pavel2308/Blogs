using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.Tests
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