using System.Text.RegularExpressions;

namespace Blogs.Markdown.Parsers.ElementParsers
{
    public class HeaderParser : BaseElementParser
    {
        string[] patternString = { @"(?m)^\s*\#.*", @"^.*\n\={3,}", @"^.*\n\-{3,}" };
        string[] patternTag = { @"(\s*\#\s*)", @"(^\={3,})", @"(^\={3,})" };
        public HeaderParser()
        {
            pattern = @"((?m)^\s*\#.*)|(^.*\n(\=|\-){3,})";
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
        public override string Parse(string mdText)
        {
            return "<h" + Level(mdText) + ">" + Text(mdText).Replace("\r", "") + "</h" + Level(mdText) + ">";
        }
    }
}
