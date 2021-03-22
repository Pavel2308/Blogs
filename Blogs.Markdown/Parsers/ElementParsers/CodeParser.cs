using System.Text.RegularExpressions;

namespace Blogs.Markdown.Parsers.ElementParsers
{
    public class CodeParser : BaseElementParser
    {
        string[] patternCode = { @"\`[^\s]+\`", @"\`\`.+\`\`" };
        string[] patternTag = { @"\s?`\s?", @"\s?``\s?" };
        public CodeParser()
        {
            pattern = @".*\`.+\`.*";
        }
        public override string Parse(string mdText)
        {
            string text = mdText;
            string code = "";
            while (Regex.IsMatch(text, pattern))
                if (Regex.IsMatch(text, patternCode[1]))
                {
                    code = Regex.Match(text, patternCode[1]).ToString();
                    code = Regex.Replace(code, patternTag[1], "");
                    code = code.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("`", "&grave;");
                    code = "<code>" + code + "</code>";
                    text = text.Replace(Regex.Match(text, patternCode[1]).ToString(), code);
                }
                else
                {
                    code = Regex.Match(text, patternCode[0]).ToString();
                    code = Regex.Replace(code, patternTag[0], "");
                    code = code.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("`", "&grave;");
                    code = "<code>" + code + "</code>";
                    text = text.Replace(Regex.Match(text, patternCode[0]).ToString(), code);
                }
            text = "<p>" + text + "</p>";
            return text;
        }
    }
}
