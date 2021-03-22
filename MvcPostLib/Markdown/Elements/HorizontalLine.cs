using System;

public class HorizontalLine
{
    public static string Pattern = @"(\*\s*){3,}";
    public static string ToHtml(string text)
    {
        return "<hr />\n";
    }
}