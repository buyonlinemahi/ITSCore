using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Core.Base.Data.SqlServer.Factory;
using System.Linq.Expressions;
namespace Core.Base.Data.SqlServer.Repository
{
    public class Base<T> where T : class
    {
        protected IUnitOfWork UnitOfWork;
        protected IDbSet<T> dbset;

        public Base(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        protected virtual IDbSet<T> GetDbSet()
        {
            return this.dbset;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToArray();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            if (where != null)
                return dbset.Where(where);
            else
                return dbset.ToArray();
        }

        public virtual IEnumerable<T> GetAll(int maxRecordCount)
        {
            if (maxRecordCount == -1)
                return dbset.ToList();
            else
                return dbset.Take(maxRecordCount);
        }

        public virtual T GetById(int id)
        {
            return dbset.Find(id);
        }

        public virtual T GetById(Guid id)
        {
            return dbset.Find(id);
        }

        public virtual T Add(T item)
        {
            item = dbset.Add(item);
            UnitOfWork.Save();
            return item;
        }

        public virtual void Delete(T item)
        {
            dbset.Remove(item);
            UnitOfWork.Save();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
            UnitOfWork.Save();
        }
    }
}
