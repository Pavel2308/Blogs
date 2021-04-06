using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Blogs
{
    public class Emphasis:Element
    {
        string[] patternTag = { @"((\*)|(_)){1}", @"((\*)|(_)){2}" };
        public Emphasis(string text="")
        {
            Pattern = @"((\*)|(_)){1,2}.+((\*)|(_)){1,2}";
            mdText = text;
        }
        public override string ToHtml()
        {
            if (Regex.IsMatch(mdText, patternTag[1]))
                return "<strong>" + Regex.Replace(mdText, patternTag[1], "").ToString() + "</strong>";
            else
                return "<em>" + Regex.Replace(mdText, patternTag[0], "").ToString() + "</em>"; ;
        }
    }
}
