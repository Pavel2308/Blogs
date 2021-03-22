using System;
using System.Text.RegularExpressions;
public class Blockquot
{
    public static string Pattern = @"(^\s*\>\s)+(.{2,}\r?\n)+\r?\n";
    public static string patternTag = @"(?m)^\>\s";
    public static string ToHtml(string text)
    {
        text = Markdown.ToHtml(Regex.Replace(text,patternTag, ""));
        text = "<blockquote>" + text + "</blockquote>";
        return text;
    }
}
