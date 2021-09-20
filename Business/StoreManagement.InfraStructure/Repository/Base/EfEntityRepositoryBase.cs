using Foundation.Abstraction.Repository;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ScheduleControl.Core.DataAccess.EntityFramework
{
    public abstract class EfEntityRepositoryBase<TEntity> : IEfRepository<TEntity>
        where TEntity : class, new()
    {

        protected readonly StoreDbContext _dbContext;
        protected EfEntityRepositoryBase(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual TEntity Add(TEntity entity)
        {
            var addedEntity = _dbContext.Add(entity);
            addedEntity.State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            var deletedEntity = _dbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }


        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter = null, List<Expression<Func<TEntity, object>>> includes = null)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.AsNoTracking().FirstOrDefault(filter);
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, List<Expression<Func<TEntity, object>>> includes = null)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return filter == null
                ? query.AsNoTracking().ToList()
                : query.AsNoTracking().Where(filter).ToList();
        }

        public virtual TEntity Update(TEntity entity)
        {
            _dbContext.Entry(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
             _dbContext.SaveChanges();
            return entity;
        }
    }
}