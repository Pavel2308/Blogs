namespace Blogs.Web.Extensions
{
    public static class HtmlDescriptionExtension
    {
        public static string ToShortHtmlDescription(this string htmlDescription)
        {
            string text = htmlDescription;
            int nWords = 0;
            string shortText = "";

            for (int i = 0; (i < text.Length) && (nWords != 15); i++)
            {
                if (text[i] == ' ')
                    nWords++;

                if (text[i] == '<')
                {
                    while ((text[i] != '>') && (i < text.Length))
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
