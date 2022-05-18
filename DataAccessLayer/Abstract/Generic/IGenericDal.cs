using System.Collections.Generic;

namespace DataAccessLayer.Abstract.Generic
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetAll();
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        T GetById(int id);
    }
}
