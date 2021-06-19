using System.Text.RegularExpressions;

namespace Blogs.Core.Markdown
{
    public class Markdown : Element
    {
        BackslashEscape backslashEscape = new BackslashEscape();
        HorizontalLine horizontalLine = new HorizontalLine();
        Image image = new Image();
        Link link = new Link();
        UnorderedList unorderedList = new UnorderedList();
        OrderedList orderedList = new OrderedList();
        CodeBlock codeBlock = new CodeBlock();
        Blockquot blockquot = new Blockquot();
        Header header = new Header();
        Code code = new Code();
        Emphasis emphasis = new Emphasis();
        public Markdown(string text="")
        {
            mdText = text;
        }
        public override string ToHtml()
        {
            string text = mdText + "\n\n";
            while (Regex.IsMatch(text, backslashEscape.Pattern))
            {
                backslashEscape.Set(Regex.Match(text, backslashEscape.Pattern).ToString());
                text = text.Replace(backslashEscape.Get(), backslashEscape.ToHtml());
            }
            while (Regex.IsMatch(text, horizontalLine.Pattern))
            {
                horizontalLine.Set(Regex.Match(text, horizontalLine.Pattern).ToString());
                text = text.Replace(horizontalLine.Get(), horizontalLine.ToHtml());
            }
            while (Regex.IsMatch(text, image.Pattern))
            {
                image.Set(Regex.Match(text, image.Pattern).ToString());
                text = text.Replace(image.Get(), image.ToHtml());
            }
            while (Regex.IsMatch(text, link.Pattern))
            {
                link.Set(Regex.Match(text, link.Pattern).ToString());
                text = text.Replace(link.Get(), link.ToHtml());
            }
            while (Regex.IsMatch(text, unorderedList.Pattern))
            {
                unorderedList.Set(Regex.Match(text, unorderedList.Pattern).ToString());
                text = text.Replace(unorderedList.Get(), unorderedList.ToHtml());
            }
            while (Regex.IsMatch(text, orderedList.Pattern))
            {
                orderedList.Set(Regex.Match(text, orderedList.Pattern).ToString());
                text = text.Replace(orderedList.Get(), orderedList.ToHtml());
            }
            while (Regex.IsMatch(text, codeBlock.Pattern))
            {
                codeBlock.Set(Regex.Match(text, codeBlock.Pattern).ToString());
                text = text.Replace(codeBlock.Get(), codeBlock.ToHtml());
            }
            while (Regex.IsMatch(text, blockquot.Pattern))
            {
                blockquot.Set(Regex.Match(text, blockquot.Pattern).ToString());
                text = text.Replace(blockquot.Get(), blockquot.ToHtml());
            }
            while (Regex.IsMatch(text, header.Pattern))
            {
                header.Set(Regex.Match(text, header.Pattern).ToString());
                text = text.Replace(header.Get(), header.ToHtml());
            }
            while (Regex.IsMatch(text, code.Pattern))
            {
                code.Set(Regex.Match(text, code.Pattern).ToString());
                text = text.Replace(code.Get(), code.ToHtml());
            }
            while (Regex.IsMatch(text, emphasis.Pattern))
            {
                emphasis.Set(Regex.Match(text, emphasis.Pattern).ToString());
                text = text.Replace(emphasis.Get(), emphasis.ToHtml());
            }
            return text;
        }
    }
}
