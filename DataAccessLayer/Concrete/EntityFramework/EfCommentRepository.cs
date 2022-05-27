using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Generic;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentsWithBlog()
        {
            using (Context context = new())
            {
                return context.Comments.Include(x => x.Blog).ToList();
            }
        }

    }
}
