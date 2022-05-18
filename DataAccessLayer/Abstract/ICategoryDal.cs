using DataAccessLayer.Abstract.Generic;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category> 
    {
    }
}
