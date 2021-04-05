using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Blogs
{
    public class Link : Element
    {
        public Link(string text="")
        {
            Pattern = @".*\[.*\]\(.*\).*\r?\n";
            mdText = text;
        }
        protected static string FindText(string text)
        {
            string PatternText = @"\[.*\]";
            return Regex.Match(text, PatternText).ToString().Replace("[", "").Replace("]", "");
        }
        protected string FindLink(string text)
        {
            string patternLink = @"\(.*\)";
            return Regex.Match(text, patternLink).ToString().Replace(" \"" + FindTitle(text) + '\"', "").Replace("(", "").Replace(")", "");
        }
        protected string FindTitle(string text)
        {
            string patternTitle = "\".*\"";
            return Regex.Match(text, patternTitle).ToString().Replace("\"", "");
        }
        public override string ToHtml()
        {
            string text = mdText;
            string patternLink = @"\[.*\]\(.*\)";
            string htmlLink = "";
            if (FindTitle(text) != "")
                htmlLink = "<a href=\"" + FindLink(text) + "\" title=\"" + FindTitle(text) + "\">" + FindText(text) + "</a>";
            else
                htmlLink = "<a href=\"" + FindLink(text) + "\">" + FindText(text) + "</a>";
            text = Regex.Replace(text, patternLink, htmlLink);
            return "<p>" + Regex.Replace(text, "\r?\n", "") + "</p>\n"; ;
        }
    }
}
