using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Foundation.Abstraction.Repository
{
    public interface IEfRepository<T> where T : class, new()
    {
        T Get(Expression<Func<T, bool>> filter = null, List<Expression<Func<T, object>>> includes = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null, List<Expression<Func<T, object>>> includes = null);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);
    }
}
