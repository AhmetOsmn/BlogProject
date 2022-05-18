using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract.Generic
{
    public interface IGenericDal<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> filter);
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        T GetById(int id);
    }
}
