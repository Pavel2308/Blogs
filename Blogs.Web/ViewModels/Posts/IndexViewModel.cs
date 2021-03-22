using System;

namespace Blogs.Web.ViewModels.Posts
{
    public class IndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; }
        public string HtmlDesc { get; set; }
        public string ShortHtmlDesc { get; set; }
    }
}
