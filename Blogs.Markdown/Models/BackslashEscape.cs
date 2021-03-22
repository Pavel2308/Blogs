namespace Blogs.Markdown.Models
{
    public class BackslashEscape
    {
        public string MdBackslashEscape { get; set; }

        public string HtmlBackslashEscape { get; set; }

        public BackslashEscape(string mdBackslashEscape,string htmlBackslashEscape) 
        {
            MdBackslashEscape = mdBackslashEscape;
            HtmlBackslashEscape = htmlBackslashEscape;
        }
    }
}
