using System.Text.RegularExpressions;

namespace Blogs.Markdown.Parsers.ElementParsers
{
    public class LinkParser : BaseElementParser
    {
        public LinkParser()
        {
            pattern = @".*\[.*\]\(.*\).*\r?\n";
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
        public override string Parse(string mdText)
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
