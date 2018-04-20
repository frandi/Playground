using PG.Common;
using PG.Model;
using System;
using System.Linq.Expressions;

namespace PG.Repository
{
    public interface IRepository<TEntity> where TEntity: BaseModel
    {
        TEntity Get(int id);
        PagedList<TEntity> Filter(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate);
        int Create(TEntity newEntity);
        void Update(TEntity updatedEntity);
        void Delete(int id);
    }
}
