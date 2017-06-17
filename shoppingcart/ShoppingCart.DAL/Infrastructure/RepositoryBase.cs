using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ShoppingCart.DAL.EF;

namespace ShoppingCart.DAL.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected readonly ApplicationDbContext DataContext;
        protected readonly IDbSet<T> Dbset;

        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DataContext = databaseFactory.Get();
            Dbset = DataContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            Dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            Dbset.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            Dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = Dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                Dbset.Remove(obj);
        }

        public virtual T GetById(long id)
        {
            return Dbset.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Dbset.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return Dbset.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return Dbset.Where(where).FirstOrDefault<T>();
        }
    }
}
