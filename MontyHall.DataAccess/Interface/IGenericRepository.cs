using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MontyHall.DataAccess.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        void Delete(T entity);

        void Add(T entity);

        void AddRange(List<T> entitys);

        void Edit(T entity);

        List<T> GetAll();

        T GetById(Expression<Func<T, bool>> predicate);

        List<T> GetByValues(Expression<Func<T, bool>> predicate);

        bool DeleteByPram(Expression<Func<T, bool>> predicate);
    }
}