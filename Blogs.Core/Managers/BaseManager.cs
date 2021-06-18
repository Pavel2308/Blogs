using Blogs.Infrastructure.Data;
//using Blogs.Web.Data;

namespace Blogs.Web.Managers
{
    public abstract class BaseManager
    {
        protected readonly BlogsContext DataContext;
        protected BaseManager(BlogsContext dataContext)
        {
            DataContext = dataContext;
        }
    }
}
