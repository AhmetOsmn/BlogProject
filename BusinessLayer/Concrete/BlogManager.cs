using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog item)
        {
            _blogDal.Add(item);
        }

        public void Delete(Blog item)
        {
            _blogDal.Delete(item);
        }
        
        public void Update(Blog item)
        {
            _blogDal.Update(item);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();   
        }
        
        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetAll(x => x.WriterId == id);
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetAll(x => x.Id == id);
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetAll().Take(3).ToList();
        }
    }
}
