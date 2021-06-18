using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Blogs.Core.Markdown
{
    public class Blockquot : Element
    {
        string patternTag= @"(?m)^\>\s";
        public Blockquot(string text = "")
        {
            Pattern = @"(^\s*\>\s)+(.{2,}\r?\n)+\r?\n";
            mdText = text;
        }
        public override string ToHtml()
        {
            string text = mdText;
            Markdown markdown = new Markdown(Regex.Replace(text, patternTag, ""));
            text = markdown.ToHtml();
            text = "<blockquote>" + text + "</blockquote>";
            return text;
        }
    }
}
