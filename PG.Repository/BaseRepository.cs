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

        public PagedList<TEntity> Filter(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Db.Set<TEntity>();
            var query = predicate != null ? entities.Where(predicate) : entities;

            return query.OrderBy(q => q.Id).ToPagedList(pageIndex, pageSize);
        }

        public TEntity Get(int id)
        {
            return Db.Set<TEntity>().Find(id);
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
