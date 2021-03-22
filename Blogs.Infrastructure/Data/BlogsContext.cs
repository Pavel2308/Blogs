using Blogs.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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
