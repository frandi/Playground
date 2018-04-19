using PG.Common;
using PG.Common.Extensions;
using PG.DataAccess;
using PG.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PG.Repository
{
    public abstract class BaseRepository<T> where T: BaseModel
    {
        protected IPlaygroundDbContext Db;

        public BaseRepository(IPlaygroundDbContext dbContext)
        {
            Db = dbContext;
        }

        public int Create(T newItem)
        {
            DbEntityEntry<T> entity = GetEntity(newItem);
            entity.State = EntityState.Added;
            Db.SaveChanges();

            return newItem.Id;
        }

        public void Delete(int id)
        {
            T item = Db.Set<T>().Find(id);
            if (item != null)
            {
                Db.Entry<T>(item).State = EntityState.Deleted;
                Db.SaveChanges();
            }
        }

        public PagedList<T> Filter(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate)
        {
            var entities = Db.Set<T>();
            var query = predicate != null ? entities.Where(predicate) : entities;

            return query.ToPagedList<T>(pageIndex, pageSize);
        }

        public T Get(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            DbEntityEntry<T> entity = GetEntity(item);
            entity.State = EntityState.Modified;
            Db.SaveChanges();
        }

        private DbEntityEntry<T> GetEntity(T newItem)
        {
            var entity = Db.Entry<T>(newItem);
            if (entity.State == EntityState.Detached)
                Db.Set<T>().Attach(newItem);
            return entity;
        }
    }
}
