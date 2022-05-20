using BusinessLayer.Abstract.Generic;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContactService : IGenericService<Contact>
    {
    }
}
