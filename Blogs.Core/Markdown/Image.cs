using System.Text.RegularExpressions;

namespace Blogs.Core.Markdown
{
    public class Image:Link
    {
        public Image(string text="")
        {
            Pattern = @".*\!\[.*\]\(.*\).*\r?\n";
            mdText = text;
        }
        public override string ToHtml()
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
