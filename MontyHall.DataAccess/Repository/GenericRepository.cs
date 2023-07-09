using MontyHall.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;

namespace MontyHall.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbSet<T> dbSet;
        private readonly Context context;
        private bool result = false;


        public GenericRepository(Context context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddRange(List<T> entitys)
        {
            try
            {
                if (entitys == null)
                {
                    throw new ArgumentNullException("entity");
                }
                dbSet.AddRange(entitys);
                //entitys.ForEach(x => dbSet.Add(x));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Edit(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                dbSet.Attach(entity);
                dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).FirstOrDefault();
        }

        public List<T> GetByValues(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public bool DeleteByPram(Expression<Func<T, bool>> predicate)
        {
            try
            {
                List<T> entitys = dbSet.Where(predicate).ToList();
                if (entitys == null)
                {
                    throw new ArgumentNullException("entity");
                }
                foreach (var item in entitys)
                {
                    dbSet.Attach(item);
                    dbSet.Remove(item);
                }
                return result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }
    }
}