using System;
using System.Text.RegularExpressions;

public class Link
{
    public static string Pattern = @".*\[.*\]\(.*\).*\r?\n";
    private static string FindText(string text)
    {
        string PatternText = @"\[.*\]";
        return Regex.Match(text, PatternText).ToString().Replace("[", "").Replace("]", "");
    }
    private static string FindLink(string text)
    {
        string patternLink = @"\(.*\)";
        return Regex.Match(text, patternLink).ToString().Replace(" \"" + FindTitle(text) + '\"', "").Replace("(", "").Replace(")", "");
    }
    private static string FindTitle(string text)
    {
        string patternTitle = "\".*\"";
        return Regex.Match(text, patternTitle).ToString().Replace("\"", "");
    }
    public static string ToHtml(string text)
    {
        string patternLink = @"\[.*\]\(.*\)";
        string htmlLink = "";
        if (FindTitle(text) != "")
            htmlLink = "<a href=\"" + FindLink(text) + "\" title=\"" + FindTitle(text) + "\">" + FindText(text) + "</a>";
        else
            htmlLink = "<a href=\"" + FindLink(text) + "\">" + FindText(text) + "</a>";
        text = Regex.Replace(text, patternLink, htmlLink);
        return "<p>" + Regex.Replace(text, "\r?\n", "") + "</p>\n";
    }
}