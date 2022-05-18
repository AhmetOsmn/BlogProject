using DataAccessLayer.Abstract.Generic;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IContactDal : IGenericDal<Contact>
    {
    }
}
