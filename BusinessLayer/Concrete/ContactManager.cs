using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void Add(Contact item)
        {
            _contactDal.Add(item);
        }

        public void Delete(Contact item)
        {
            _contactDal.Delete(item);
        }

        public List<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public Contact GetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public void Update(Contact item)
        {
            _contactDal.Update(item);
        }
    }
}
