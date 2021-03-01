using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Core.Entities.Concrete;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
