using PG.Common;
using PG.Common.Extensions;
using PG.DataAccess;
using PG.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace PG.Repository
{
    public abstract class BaseRepository<TEntity> where TEntity: BaseModel
    {
        protected IPlaygroundDbContext Db;

        protected BaseRepository(IPlaygroundDbContext dbContext)
        {
            Db = dbContext;
        }

        public int Create(TEntity newEntity)
        {
            var dbEntity = GetEntity(newEntity);
            dbEntity.State = EntityState.Added;
            
            Db.SaveChanges();

            return newEntity.Id;
        }

        public void Delete(int id)
        {
            TEntity entity = Get(id);
            if (entity != null)
            {
                Db.Entry(entity).State = EntityState.Deleted;
                Db.SaveChanges();
            }
        }

        public PagedList<TEntity> Filter<TKey>(int pageIndex, int pageSize, OrderBySelector<TEntity, TKey> orderBySelector, Expression<Func<TEntity, bool>> whereFilter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> entities = Db.Set<TEntity>();
            foreach (var prop in includeProperties)
            {
                entities = entities.Include(prop);
            }

            entities = orderBySelector.Type == OrderByType.Ascending
                ? entities.OrderBy(orderBySelector.Selector)
                : entities.OrderByDescending(orderBySelector.Selector);

            var query = whereFilter != null ? entities.Where(whereFilter) : entities;

            return query.ToPagedList(pageIndex, pageSize);
        }

        public TEntity Get(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public TEntity Get(int id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var pagedList = Filter(1, 1, 
                new OrderBySelector<TEntity, int>(OrderByType.Ascending, entity => entity.Id),
                entity => entity.Id == id, includeProperties);

            return pagedList.TotalCount > 0 ? pagedList.Items.FirstOrDefault() : null;
        }

        public void Update(TEntity updatedEntity)
        {
            var dbEntity = GetEntity(updatedEntity);
            dbEntity.State = EntityState.Modified;

            Db.SaveChanges();
        }

        private DbEntityEntry<TEntity> GetEntity(TEntity entity)
        {
            var dbEntity = Db.Entry(entity);
            if (dbEntity.State == EntityState.Detached)
                Db.Set<TEntity>().Attach(entity);
            return dbEntity;
        }
    }
}
