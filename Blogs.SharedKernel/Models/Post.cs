using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
