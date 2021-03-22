using System;
using System.ComponentModel.DataAnnotations;

namespace MvcPost.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Category { get; set; }
        public string LongDesc { get; set; }
        public string ShortDesc { get; set; }
    }
}
