using Microsoft.EntityFrameworkCore;
using MvcPost.Models;

namespace MvcPost.Data
{
    public class MvcPostContext : DbContext
    {
        public MvcPostContext(DbContextOptions<MvcPostContext> options)
    : base(options)
        {
        }

        public DbSet<Post> Post { get; set; }
    }
}
