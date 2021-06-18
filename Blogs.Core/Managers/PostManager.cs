using Blogs.Infrastructure.Data;
//using Blogs.Web.Data;
using Blogs.SharedKernel.Models;
using System.Collections.Generic;
using System.Linq;

namespace Blogs.Web.Managers
{
    public class PostManager : BaseManager
    {
        public PostManager(BlogsContext dataContext) : base(dataContext)
        { }
        public List<Post> List()
        {
            return DataContext.Posts.ToList();
        }
        public Post GetPostById(int id)
        {
            return DataContext.Posts.Find(id);
        }
        public void Insert(Post post)
        {
            DataContext.Posts.Add(post);
            DataContext.SaveChanges();
        }
        public void Update(Post post)
        {
            DataContext.Posts.Update(post);
            DataContext.SaveChanges();
        }
        public void Delete(Post post)
        {
            DataContext.Posts.Remove(post);
            DataContext.SaveChanges();
        }
        public bool Exists(int id)
        {
            return DataContext.Posts.Any(e => e.Id == id);
        }
        public string GetShortHtmlDesc(string HtmlDesc)
        {
            string text = HtmlDesc;
            int nWords = 0;
            string shortText = "";
            for (int i = 0; (i < text.Length) && (nWords != 15); i++)
            {
                if (text[i] == ' ')
                    nWords++;
                if (text[i] == '<')
                {
                    while ((text[i] != '>') && (i < text.Length))
                    {
                        i++;
                    }
                }
                else
                    shortText += text[i];
            }
            return shortText + "...";
        }
    }
}
