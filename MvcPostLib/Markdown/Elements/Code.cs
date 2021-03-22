using System;
using System.Text.RegularExpressions;

public class Code
{
    public static string Pattern = @".*\`.+\`.*";
    private static string[] patternCode = { @"\`[^\s]+\`", @"\`\`.+\`\`", };
    private static string[] patternTag = { @"\s?`\s?", @"\s?``\s?" };
    public static string ToHtml(string text)
    {
        string code = "";
        while(Regex.IsMatch(text, Pattern))
                if (Regex.IsMatch(text, patternCode[1]))
        {
            code = Regex.Match(text, patternCode[1]).ToString();
            code = Regex.Replace(code, patternTag[1], "");
            code = code.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("`", "&grave;");
            code = "<code>" + code + "</code>";
            text = text.Replace(Regex.Match(text, patternCode[1]).ToString(), code);
        }
        else
        {
            code = Regex.Match(text, patternCode[0]).ToString();
            code = Regex.Replace(code, patternTag[0], "");
            code = code.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("`", "&grave;");
            code = "<code>" + code + "</code>";
            text = text.Replace(Regex.Match(text, patternCode[0]).ToString(), code);
        }
        text = "<p>" + text + "</p>";
        return text;
    }
}
