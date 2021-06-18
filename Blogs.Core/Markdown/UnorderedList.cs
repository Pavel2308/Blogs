using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.Core.Markdown
{
    public class UnorderedList: List
    {
        public UnorderedList(string text = "")
        {
            patternString = @"(\*+|\++|\-+)\s*.*";
            Pattern = @"(((?m)^(\*+|\++|\-+)\s+((\r?\n(\s{4})+)*(.{2,}\r?\n)+)+)+)";
            patternTag = @"((\*+|\++|\-+)\s*)";
            mdText = text;
        }
        public override string ToHtml()
        {
            string[] list = SetList(mdText);
            string text = "";
            foreach (string element in list)
            {
                text += "<li>" + element.Replace("\r", "") + "</li>\n";
            }
            return "<ul>\n" + text + "</ul>\n";
        }
    }
}
