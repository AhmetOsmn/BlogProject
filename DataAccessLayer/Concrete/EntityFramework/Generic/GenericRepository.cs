using DataAccessLayer.Abstract.Generic;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Concrete.EntityFramework.Generic
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Add(T item)
        {
            using Context context = new();
            context.Add(item);
            context.SaveChanges();
        }

        public void Delete(T item)
        {
            using Context context = new();
            context.Remove(item);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            using Context context = new();
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using Context context = new();
            return context.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            using Context context = new();
            context.Update(item);
            context.SaveChanges();
        }
    }
}
