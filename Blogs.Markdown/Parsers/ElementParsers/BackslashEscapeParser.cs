using Blogs.Markdown.Models;

namespace Blogs.Markdown.Parsers.ElementParsers
{
    public class BackslashEscapeParser : BaseElementParser
    {
        private readonly IEnumerable<BackslashEscape> _backslashEscapes;

        public BackslashEscapeParser()
        {
            pattern = @"\\((\\)|(\`)|(\*)|(_)|(\{)|(\})
|                         (\[)|(\])|(\()|(\))|(\#)|(\+)|(\-)|(\.)|(\!))";

            _backslashEscapes = new List<BackslashEscape>
            {
                new BackslashEscape(@"\\","&#92;"),
                new BackslashEscape(@"\`","&#96;"),
                new BackslashEscape(@"\*","&#42;"),
                new BackslashEscape(@"\_","&#95;"),
                new BackslashEscape(@"\{","&#123;"),
                new BackslashEscape(@"\}","&#125;"),
                new BackslashEscape(@"\[","&#91;"),
                new BackslashEscape(@"\]","&#93;"),
                new BackslashEscape(@"\(","&#40;"),
                new BackslashEscape(@"\)","&#41;"),
                new BackslashEscape(@"\#","&#35;"),
                new BackslashEscape(@"\+","&#43;"),
                new BackslashEscape(@"\-","&#45;"),
                new BackslashEscape(@"\.","&#46;"),
                new BackslashEscape(@"\!","&#33;"),
            };
        }

        public override string Parse(string mdText)
        {
            foreach (var backslashEscape in _backslashEscapes)
            {
                if (backslashEscape.MdBackslashEscape.Contains(mdText))
                    return backslashEscape.HtmlBackslashEscape;
            }

            return mdText;
        }
    }
}
