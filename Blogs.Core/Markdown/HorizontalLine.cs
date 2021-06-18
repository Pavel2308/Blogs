using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.Core.Markdown
{
    public class HorizontalLine : Element
    {
        public HorizontalLine(string text="")
        {
            Pattern = @"(\*\s*){3,}";
            mdText = text;
        }
        public override string ToHtml()
        {
            return "<hr />\n"; ;
        }
    }
}
