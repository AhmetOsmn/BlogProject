using DataAccessLayer.Abstract.Generic;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal : IGenericDal<User>
    {
    }
}
