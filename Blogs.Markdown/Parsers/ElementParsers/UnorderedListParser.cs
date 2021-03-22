namespace Blogs.Markdown.Parsers.ElementParsers
{
    public class UnorderedListParser : BaseListParser
    {
        public UnorderedListParser(string text = "")
        {
            patternString = @"(\*+|\++|\-+)\s*.*";
            pattern = @"(((?m)^(\*+|\++|\-+)\s+((\r?\n(\s{4})+)*(.{2,}\r?\n)+)+)+)";
            patternTag = @"((\*+|\++|\-+)\s*)";
        }
        public override string Parse(string mdText)
        {
            string[] list = SetList(mdText);
            string text = "";
            foreach (string element in list)
            {
                text += "<li>" + element.Replace("\r", "") + "</li>\n";
            }
            return "<ul>\n" + text + "</ul>\n";
        }
    }
}
