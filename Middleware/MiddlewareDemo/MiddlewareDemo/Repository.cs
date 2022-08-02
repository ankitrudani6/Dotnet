using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiddlewareDemo.Models;

namespace MiddlewareDemo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        TEntity Delete(TEntity entity);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        public DotnetDBContext DbContext { get; set; }
        public Repository(DotnetDBContext dotnetDBContext)
        {
            DbContext = dotnetDBContext;
        }

        public List<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public T Add(T entity)
        {
            DbContext.Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            DbContext.SaveChanges();

            return entity;
        }
    }
}
