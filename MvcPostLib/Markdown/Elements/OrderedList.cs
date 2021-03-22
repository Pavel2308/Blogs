using System;
using System.Text.RegularExpressions;

public class OrderedList
{
    private static string patternString = @"[1-9]\..*";
    public static string Pattern = @"(([1-9]\.\s+((\r?\n(\s{4})+)*(.{2,}\r?\n)+)+)+)";
    private static string patternTag = @"([1-9]\.\s*)";

    private static string[] List(string text)
    {
        Regex.Match(text, patternTag);
        string[] list = new string[1];
        for (int i = 0; Regex.IsMatch(text, patternString); i++)
        {
            Array.Resize(ref list, i + 1);
            list[i] = Regex.Match(text, patternString).ToString();
            text = text.Replace(list[i], "");
            list[i] = Regex.Replace(list[i], patternTag, String.Empty).ToString();
        }
        return list;
    }
    public static string ToHtml(string text)
    {
        string[] list = List(text);
        text = "";
        foreach (string element in list)
        {
            text += "<li>" + element.Replace("\r", "") + "</li>\n";
        }
        return "<ol>\n" + text + "</ol>\n";
    }
}
