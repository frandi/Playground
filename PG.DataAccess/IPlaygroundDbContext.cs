using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace PG.DataAccess
{
    public interface IPlaygroundDbContext : IDisposable
    {
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity: class;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
