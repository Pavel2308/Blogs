
namespace Blogs.Core.Markdown
{
    public abstract class Element
    {
        protected string mdText;
        public string Pattern;
        public void Set(string mkText)
        {
            mdText = mkText;
        }
        public abstract string ToHtml();
        public string Get()
        {
            return mdText;
        }
    }
}
