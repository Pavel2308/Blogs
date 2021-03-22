using System;
using System.Text.RegularExpressions;

namespace Blogs.Markdown.Parsers.ElementParsers
{

    public abstract class BaseListParser : BaseElementParser
    {
        protected string patternString;
        protected string patternTag;
        protected string[] SetList(string text)
        {
            Regex.Match(text, patternTag);
            string[] list = new string[1];
            for (int i = 0; Regex.IsMatch(text, patternString); i++)
            {
                Array.Resize(ref list, i + 1);
                list[i] = Regex.Match(text, patternString).ToString();
                text = text.Replace(list[i], "");
                list[i] = Regex.Replace(list[i], patternTag, string.Empty).ToString();
            }
            return list;
        }
    }
}
