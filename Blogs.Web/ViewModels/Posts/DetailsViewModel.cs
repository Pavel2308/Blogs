using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Web.ViewModels.Posts
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; }
        public string HtmlDesc { get; set; }
    }
}
