using System;
using System.Text.RegularExpressions;

public class CodeBlock
{
    public static string Pattern = @".*(\r?\n){2}((?m)^\s{4}.+)+";
    private static string PatternText = @".*(\r?\n){2}";
    private static string PatternTag = @"(?m)^\s{4}";
    private static string Code(string text)
    {
        text = text.Replace(Regex.Match(text, PatternText).ToString(), "");
        text = Regex.Replace(text, PatternTag, "");
        text = text.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
        return text;
    }
    private static string Text(string text)
    {
        text =Regex.Replace(Regex.Match(text, PatternText).ToString(),"\r?\n", "").ToString();
        return text;
    }
    public static string ToHtml(string text)
    {
        return "<p>" + Text(text) + "</p>" + "\n\n" + "<pre><code>" + Code(text) + "\n</code></pre>";
    }
}