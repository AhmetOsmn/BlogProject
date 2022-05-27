using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commetDal)
        {
            _commentDal = commetDal;
        }

        public void Add(Comment item)
        {
            _commentDal.Add(item);
        }

        public void Delete(Comment item)
        {
            _commentDal.Delete(item);
        }

        public void Update(Comment item)
        {
            _commentDal.Update(item);
        }

        public List<Comment> GetAll()
        {
            return _commentDal.GetAll();
        }

        public Comment GetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> GetAllByBlog(int id)
        {
            return _commentDal.GetAll(x => x.BlogId == id);
        }

        public List<Comment> GetAllWithBlog()
        {
            return _commentDal.GetCommentsWithBlog();
        }
    }
}
