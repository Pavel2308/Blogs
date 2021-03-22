using Blogs.Markdown.Intefaces;
using System.Text.RegularExpressions;

namespace Blogs.Markdown.Parsers.ElementParsers
{
    public abstract class BaseElementParser : IElementParser
    {
        protected string pattern { init; get; }

        public abstract string Parse(string mdText);

        public bool IsElementFound(string text)
        {
            return Regex.IsMatch(text, pattern);
        }

        public string GetFirstElement(string text)
        {
            return Regex.Match(text, pattern).ToString();
        }
    }
}
