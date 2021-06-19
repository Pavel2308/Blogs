using Blogs.Infrastructure.Data;

namespace Blogs.Web.Managers
{
    public abstract class BaseManager
    {
        protected readonly BlogsContext _context;
        protected BaseManager(BlogsContext context)
        {
            _context = context;
        }
    }
}
