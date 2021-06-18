using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Blogs.Core.Markdown
{
    public class CodeBlock : Element
    {
        string PatternText = @".*(\r?\n){2}";
        string PatternTag = @"(?m)^\s{4}";
        public CodeBlock(string text="")
        {
            Pattern = @".*(\r?\n){2}((?m)^\s{4}.+)+";
            mdText = text;
        }
        private string Code(string text)
        {
            text = text.Replace(Regex.Match(text, PatternText).ToString(), "");
            text = Regex.Replace(text, PatternTag, "");
            text = text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
            return text;
        }
        private string Text(string text)
        {
            text = Regex.Replace(Regex.Match(text, PatternText).ToString(), "\r?\n", "").ToString();
            return text;
        }
        public override string ToHtml()
        {
            return "<p>" + Text(mdText) + "</p>" + "\n\n" + "<pre><code>" + Code(mdText) + "\n</code></pre>"; ;
        }
    }
}
