using System;
using System.Text.RegularExpressions;

public class Emphasis
{
    public static string Pattern = @"((\*)|(_)){1,2}.+((\*)|(_)){1,2}";
    private static string[] patternTag = { @"((\*)|(_)){1}", @"((\*)|(_)){2}" };
    public static string ToHtml(string text)
    {
        if (Regex.IsMatch(text, patternTag[1]))
            return "<strong>" + Regex.Replace(text, patternTag[1], "").ToString() + "</strong>";
        else
            return "<em>" + Regex.Replace(text, patternTag[0], "").ToString() + "</em>";
    }
}
