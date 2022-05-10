using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
