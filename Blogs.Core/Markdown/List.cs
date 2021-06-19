using System;
using System.Text.RegularExpressions;

namespace Blogs.Core.Markdown
{

    public abstract class List : Element
    {
        protected string patternString;
        protected string patternTag;
        protected string[] SetList(string text)
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
    }
}
