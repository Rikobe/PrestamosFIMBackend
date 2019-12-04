using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace PrestamosFIM.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
