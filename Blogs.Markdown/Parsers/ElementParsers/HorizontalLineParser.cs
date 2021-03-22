namespace Blogs.Markdown.Parsers.ElementParsers
{
    public class HorizontalLineParser : BaseElementParser
    {
        public HorizontalLineParser()
        {
            pattern = @"(\*\s*){3,}";
        }
        public override string Parse(string mdText)
        {
            return "<hr />\n"; ;
        }
    }
}
