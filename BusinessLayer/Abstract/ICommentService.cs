using BusinessLayer.Abstract.Generic;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
    }
}
