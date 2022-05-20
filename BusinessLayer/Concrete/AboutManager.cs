using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AboutManager: IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About item)
        {
            _aboutDal.Add(item);
        }

        public void Delete(About item)
        {
            _aboutDal.Delete(item); 
        }

        public List<About> GetAll()
        {
            return _aboutDal.GetAll();
        }

        public About GetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public void Update(About item)
        {
            _aboutDal.Update(item);
        }
    }
}
