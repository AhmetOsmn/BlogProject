using BusinessLayer.Abstract.Generic;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IUserService : IGenericService<User> 
    {
    }
}
