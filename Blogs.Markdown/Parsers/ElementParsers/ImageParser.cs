using System.Text.RegularExpressions;

namespace Blogs.Markdown.Parsers.ElementParsers
{
    public class ImageParser : LinkParser
    {
        public ImageParser()
        {
            pattern = @".*\!\[.*\]\(.*\).*\r?\n";
        }
        public override string Parse(string mdText)
        {
            string text = mdText;
            string patternLink = @"\!\[.*\]\(.*\)";
            string htmlLink = "";
            if (FindTitle(text) != "")
                htmlLink = "<img src=\"" + FindLink(text) + "\" title=\"" + FindTitle(text) + "\" alt=\"" + FindText(text) + "\">";
            else
                htmlLink = "<img src=\"" + FindLink(text) + "\"" + " alt=\"" + FindText(text) + "\">"; ;
            text = Regex.Replace(text, patternLink, htmlLink);
            return "<p>" + Regex.Replace(text, "\r?\n", "") + "</p>\n"; ;
        }
    }
}
