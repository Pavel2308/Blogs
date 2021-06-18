using Blogs.SharedKernel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogs.Infrastructure.Data
{
    public class BlogsContext : DbContext
    {
        public BlogsContext(DbContextOptions<BlogsContext> options)
    : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
