using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Generic;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public int GetCommentCount(int id)
        {
            using (Context context = new())
            {
                return context.Comments.Where(x => x.BlogId == id).Count();
            }
        }

        public List<Blog> GetListWithCategory()
        {
            using (Context context = new())
            {
                return context.Blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (Context context = new())
            {
                return context.Blogs.Include(x => x.Category).Where(x => x.WriterId == id).ToList();
            }
        }
    }
}
