using System;
using System.Collections.Generic;
using System.Text;

namespace MvcPostLib
{
    public class Posts
    {
        public static string Short(string text)
        {
            text=Markdown.ToHtml(text);
            int nWords = 0;
            string shortText = "";
            for (int i = 0; (i < text.Length)&&(nWords!=15); i++)
            {
                if (text[i] == ' ')
                    nWords++;
                if (text[i] == '<')
                {
                    while ((text[i]!='>')&&(i < text.Length))
                    {
                        i++;
                    }
                }
                else
                    shortText += text[i];
            }
            return shortText + "...";
        }
    }
}
