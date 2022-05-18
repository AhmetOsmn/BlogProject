using System.Collections.Generic;

namespace BusinessLayer.Abstract.Generic
{
    public interface IGenericService<T> where T : class
    {
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        List<T> GetAll();
        T GetById(int id);
    }
}
