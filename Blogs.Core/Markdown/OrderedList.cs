
namespace Blogs.Core.Markdown
{
    public class OrderedList : List
    {
        public OrderedList(string text = "")
        {
        patternString = @"[1-9]\..*";
        Pattern = @"(([1-9]\.\s+((\r?\n(\s{4})+)*(.{2,}\r?\n)+)+)+)";
        patternTag = @"([1-9]\.\s*)";
        mdText = text;
        }
        public override string ToHtml()
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
