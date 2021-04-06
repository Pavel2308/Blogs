using Microsoft.EntityFrameworkCore;
using MvcBlogs.Models;

namespace MvcBlogs.Data
{
    public class MvcBlogsContext: DbContext
    {
        public MvcBlogsContext(DbContextOptions<MvcBlogsContext> options)
    : base(options)
        {
        }

        public DbSet<Post> Post { get; set; }
    }
}
