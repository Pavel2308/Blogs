namespace Blogs.Markdown.Parsers.ElementParsers
{
    public class OrderedListParser : BaseListParser
    {
        public OrderedListParser()
        {
            patternString = @"[1-9]\..*";
            pattern = @"(([1-9]\.\s+((\r?\n(\s{4})+)*(.{2,}\r?\n)+)+)+)";
            patternTag = @"([1-9]\.\s*)";
        }
        public override string Parse(string mdText)
        {
            string[] list = SetList(mdText);
            string text = "";
            foreach (string element in list)
            {
                text += "<li>" + element.Replace("\r", "") + "</li>\n";
            }
            return "<ol>\n" + text + "</ol>\n";
        }
    }
}
