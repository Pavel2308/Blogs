using System;

public class BackslashEscape
{
    public static string Pattern = @"\\((\\)|(\`)|(\*)|(_)|(\{)|(\})
|                         (\[)|(\])|(\()|(\))|(\#)|(\+)|(\-)|(\.)|(\!))";
    public static string ToHtml(string text)
    {
        switch (text)
            {
                case @"\\":
                    return "&#92;";
                case @"\`":
                    return "&#96;";
                case @"\*":
                    return "&#42;";
                case @"\_":
                    return "&#95;";
                case @"\{":
                    return "&#123;";
                case @"\}":
                    return "&#125;";
                case @"\[":
                    return "&#91;";
                case @"\]":
                    return "&#93;";
                case @"\(":
                    return "&#40;";
                case @"\)":
                    return "&#41;";
                case @"\#":
                    return "&#35;";
                case @"\+":
                    return "&#43;";
                case @"\-":
                    return "&#45;";
                case @"\.":
                    return "&#46;";
                case @"\!":
                    return "&#33;";
                default:
                    return text;
            }
    }
}


