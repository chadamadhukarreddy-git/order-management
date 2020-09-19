using Microsoft.EntityFrameworkCore;
using OrderManagement.DBEntities.Models;
using OrderManagement.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace OrderManagement.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> 
        where TEntity : class
    {
        protected OrderManagementDbContext RepositoryContext { get; set; }
        public RepositoryBase(OrderManagementDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public IQueryable<TEntity> GetAll()
        {
            return this.RepositoryContext.Set<TEntity>().AsNoTracking();
        }
        public TEntity Get<TId>(TId id)
        {
            return this.RepositoryContext.Set<TEntity>().Find(id);
        }
        public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return this.RepositoryContext.Set<TEntity>().Where(expression).AsNoTracking();
        }
        public TEntity Create(TEntity entity)
        {
            return this.RepositoryContext.Set<TEntity>().Add(entity).Entity;
        }
        public TEntity Update(TEntity entity)
        {
            return this.RepositoryContext.Set<TEntity>().Update(entity).Entity;
        }
        public void Delete(TEntity entity)
        {
            this.RepositoryContext.Set<TEntity>().Remove(entity);
        }
    }
}
