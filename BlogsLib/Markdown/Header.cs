using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Blogs
{
    public class Header : Element
    {
        string[] patternString = { @"(?m)^\s*\#.*", @"^.*\n\={3,}", @"^.*\n\-{3,}" };
        string[] patternTag = { @"(\s*\#\s*)", @"(^\={3,})", @"(^\={3,})" };
        public Header(string text="")
        {
            Pattern = @"((?m)^\s*\#.*)|(^.*\n(\=|\-){3,})";
            mdText = text;
        }
        private int Level(string text)
        {
            if (Regex.IsMatch(text, patternString[0]))
            {
                int i = 0;
                while (text[i] == '#')
                    i++;
                return i;
            }
            else
            {
                if (Regex.IsMatch(text, patternString[1]))
                    return 1;
                else
                    return 2;
            }
        }
        private string Text(string text)
        {
            if (Regex.IsMatch(text, patternString[0]))
            {
                return Regex.Replace(text, patternTag[0], "");
            }
            else
                return Regex.Match(text, ".*").ToString();
        }
        public override string ToHtml()
        {
            return "<h" + Level(mdText) + ">" + Text(mdText).Replace("\r", "") + "</h" + Level(mdText) + ">";
        }
    }
}
