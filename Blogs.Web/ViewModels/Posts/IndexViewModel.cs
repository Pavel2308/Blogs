using Blogs.SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blogs.Web.ViewModels.Posts
{
    public class IndexViewModel:Post
    {
        public string ShortHtmlDesc { get; set; }
    }
}
