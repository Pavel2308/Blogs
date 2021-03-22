using System.Text.RegularExpressions;

namespace Blogs.Markdown.Parsers.ElementParsers
{
    public class BlockquotParser : BaseElementParser
    {
        string patternTag = @"(?m)^\>\s";
        public BlockquotParser()
        {
            pattern = @"(^\s*\>\s)+(.{2,}\r?\n)+\r?\n";
        }
        public override string Parse(string mdText)
        {
            string text = mdText;
            text = "<blockquote>" + Regex.Replace(text, patternTag, "") + "</blockquote>";
            return text;
        }
    }
}
