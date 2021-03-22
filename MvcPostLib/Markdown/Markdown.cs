using System;
using System.Text.RegularExpressions;

public class Markdown
{
    public static string ToHtml(string text)
    {
        text += "\n\n";
        string element;
        while (Regex.IsMatch(text, BackslashEscape.Pattern))
        {
            element = Regex.Match(text, BackslashEscape.Pattern).ToString();
            text = text.Replace(element, BackslashEscape.ToHtml(element));
        }
        while (Regex.IsMatch(text, HorizontalLine.Pattern))
        {
            element = Regex.Match(text, HorizontalLine.Pattern).ToString();
            text = text.Replace(element, HorizontalLine.ToHtml(element));
        }
        while (Regex.IsMatch(text, Image.Pattern))
        {
            element = Regex.Match(text, Image.Pattern).ToString();
            text = text.Replace(element, Image.ToHtml(element));
        }
        while (Regex.IsMatch(text, Link.Pattern))
        {
            element = Regex.Match(text, Link.Pattern).ToString();
            text = text.Replace(element, Link.ToHtml(element));
        }
        while (Regex.IsMatch(text, UnorderedList.Pattern))
        {
            element = Regex.Match(text, UnorderedList.Pattern).ToString();
            text = text.Replace(element, UnorderedList.ToHtml(element));
        }
        while (Regex.IsMatch(text, OrderedList.Pattern))
        {
            element = Regex.Match(text, OrderedList.Pattern).ToString();
            text = text.Replace(element, OrderedList.ToHtml(element));
        }
        while (Regex.IsMatch(text, CodeBlock.Pattern))
        {
            element = Regex.Match(text, CodeBlock.Pattern).ToString();
            text = text.Replace(element, CodeBlock.ToHtml(element));
        }
        while (Regex.IsMatch(text, Blockquot.Pattern))
        {
            element = Regex.Match(text, Blockquot.Pattern).ToString();
            text = text.Replace(element, Blockquot.ToHtml(element));
        }
        while (Regex.IsMatch(text, Header.Pattern))
        {
            element = Regex.Match(text, Header.Pattern).ToString();
            text = text.Replace(element, Header.ToHtml(element));
        }
        while (Regex.IsMatch(text, Code.Pattern))
        {
            element = Regex.Match(text, Code.Pattern).ToString();
            text = text.Replace(element, Code.ToHtml(element));
        }
        while (Regex.IsMatch(text, Emphasis.Pattern))
        {
            element = Regex.Match(text, Emphasis.Pattern).ToString();
            text = text.Replace(element, Emphasis.ToHtml(element));
        }
        return text;
    }
}

