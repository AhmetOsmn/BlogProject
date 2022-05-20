using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newsLetter;

        public NewsLetterManager(INewsLetterDal newsLetter)
        {
            _newsLetter = newsLetter;
        }

        public void Add(NewsLetter item)
        {
            _newsLetter.Add(item);
        }

        public void Delete(NewsLetter item)
        {
            _newsLetter.Delete(item);
        }

        public List<NewsLetter> GetAll()
        {
            return _newsLetter.GetAll();
        }

        public NewsLetter GetById(int id)
        {
            return _newsLetter.GetById(id);
        }

        public void Update(NewsLetter item)
        {
            _newsLetter.Update(item);
        }
    }
}
