using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Web.ViewModels.Posts
{
    public class CreateViewModel
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string MdDesc { get; set; }
    }
}
