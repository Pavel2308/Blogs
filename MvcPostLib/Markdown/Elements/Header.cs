using System;
using System.Text.RegularExpressions;

public class Header
{
    public static string Pattern = @"(^\s*\#.*)|(^.*\n(\=|\-){3,})";
    private static string[] patternString = { @"^\s*\#.*", @"^.*\n\={3,}", @"^.*\n\-{3,}" };
    private static string[] patternTag = { @"(\s*\#\s*)", @"(^\={3,})", @"(^\={3,})"};
    private static int Level(string text)
    {
        if (Regex.IsMatch(text, patternString[0]))
        {
            int i = 0;
            while (text[i] == '#')
                i++;
            return i;
        }
        else
        {
            if (Regex.IsMatch(text, patternString[1]))
                return 1;
            else
                return 2;
        }
    }
    private static string Text(string text)
    {
        if (Regex.IsMatch(text, patternString[0]))
        {
            return Regex.Replace(text, patternTag[0], "");
        }
        else
            return Regex.Match(text, ".*").ToString();
    }
    public static string ToHtml(string text)
    {
        return "<h" + Level(text) + ">" + Text(text).Replace("\r", "") + "</h" + Level(text) + ">";
    }
}
