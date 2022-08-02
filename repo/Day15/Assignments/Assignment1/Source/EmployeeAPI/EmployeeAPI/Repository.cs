using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAPI.Models;

namespace EmployeeAPI
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        TEntity Delete(TEntity entity);

        TEntity Put(TEntity entity, TEntity newEntity);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        public EmployeeDBContext DbContext { get; set; }
        public Repository(EmployeeDBContext empDbContext)
        {
            DbContext = empDbContext;
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

        public T Put(T entity, T newEntity)
        {
            DbContext.Entry(entity).CurrentValues.SetValues(newEntity);
            DbContext.SaveChanges();
            return newEntity;
        }
    }
}
