using BusinessLayer.Abstract.Generic;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> GetAllByBlog(int id);
        List<Comment> GetAllWithBlog();
    }
}
