using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OrderManagement.Repositories.Contracts
{
    public interface IRepositoryBase<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity Get<TId>(TId id);
        IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
