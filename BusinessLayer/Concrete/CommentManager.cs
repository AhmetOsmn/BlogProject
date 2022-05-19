using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commetDal;

        public CommentManager(ICommentDal commetDal)
        {
            _commetDal = commetDal;
        }

        public void Add(Comment item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Comment item)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAllByBlog(int id)
        {
            return _commetDal.GetAll(x => x.BlogId == id);
        }

        public List<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment item)
        {
            throw new NotImplementedException();
        }
    }
}
