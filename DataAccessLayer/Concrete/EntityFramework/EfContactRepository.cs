using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Generic;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfContactRepository: GenericRepository<Contact>, IContactDal
    {
    }
}
