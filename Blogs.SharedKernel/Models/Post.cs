using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogs.SharedKernel.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; }
        public string MdDesc { get; set; }
        public string HtmlDesc { get; set; }
        public string ShortHtmlDesc()
        {
            string text = HtmlDesc;
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
