using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
namespace Core.Base.Data
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll(int maxRecordCount);
        T GetById(int id);
        T GetById(Guid id);
        T Add(T item);
        void Update(T entity);
        int Update(T item, params Expression<Func<T, object>>[] properties);
        void Delete(T item);
        void Delete(Expression<Func<T, bool>> where);
    }
}
