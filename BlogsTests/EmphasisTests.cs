using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.Tests
{
    [TestClass()]
    public class EmphasisTests
    {
        Emphasis emphasis = new Emphasis();
        [TestMethod()]
        public void ToHtml_SingleAsterisks_ReturnsEm()
        {
            string input = "*single asterisks*";
            string expected = "<em>single asterisks</em>";
            emphasis.Set(input);
            string actual= emphasis.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_SingleUnderscores_ReturnsEm()
        {
            string input = "_single underscores_";
            string expected = "<em>single underscores</em>";
            emphasis.Set(input);
            string actual = emphasis.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_DoubleAsterisks_ReturnsStrong()
        {
            string input = "**double asterisks**";
            string expected = "<strong>double asterisks</strong>";
            emphasis.Set(input);
            string actual = emphasis.ToHtml();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ToHtml_DoubleUnderscores_ReturnsStrong()
        {
            string input = "__double underscores__";
            string expected = "<strong>double underscores</strong>";
            emphasis.Set(input);
            string actual = emphasis.ToHtml();
            Assert.AreEqual(expected, actual);
        }
    }
}