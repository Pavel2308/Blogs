using System.Text.RegularExpressions;

namespace Blogs.Markdown.Parsers.ElementParsers
{
    public class EmphasisParser : BaseElementParser
    {
        string[] patternTag = { @"((\*)|(_)){1}", @"((\*)|(_)){2}" };
        public EmphasisParser()
        {
            pattern = @"((\*)|(_)){1,2}.+((\*)|(_)){1,2}";
        }
        public override string Parse(string mdText)
        {
            if (Regex.IsMatch(mdText, patternTag[1]))
                return "<strong>" + Regex.Replace(mdText, patternTag[1], "").ToString() + "</strong>";
            else
                return "<em>" + Regex.Replace(mdText, patternTag[0], "").ToString() + "</em>"; ;
        }
    }
}
