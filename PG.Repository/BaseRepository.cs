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
    public abstract class BaseRepository<T> where T: BaseModel
    {
        protected IPlaygroundDbContext Db;

        protected BaseRepository(IPlaygroundDbContext dbContext)
        {
            Db = dbContext;
        }

        public int Create(T newItem)
        {
            newItem.Created = DateTime.UtcNow;

            var entity = GetEntity(newItem);
            entity.State = EntityState.Added;
            
            Db.SaveChanges();

            return newItem.Id;
        }

        public void Delete(int id)
        {
            T item = Db.Set<T>().Find(id);
            if (item != null)
            {
                Db.Entry(item).State = EntityState.Deleted;
                Db.SaveChanges();
            }
        }

        public PagedList<T> Filter(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate)
        {
            var entities = Db.Set<T>();
            var query = predicate != null ? entities.Where(predicate) : entities;

            return query.OrderBy(q => q.Id).ToPagedList(pageIndex, pageSize);
        }

        public T Get(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            item.Updated = DateTime.UtcNow;

            var entity = GetEntity(item);
            entity.State = EntityState.Modified;
            Db.SaveChanges();
        }

        private DbEntityEntry<T> GetEntity(T newItem)
        {
            var entity = Db.Entry(newItem);
            if (entity.State == EntityState.Detached)
                Db.Set<T>().Attach(newItem);
            return entity;
        }
    }
}
