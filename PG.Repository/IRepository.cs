using PG.Common;
using PG.Model;
using System;
using System.Linq.Expressions;

namespace PG.Repository
{
    public interface IRepository<T> where T: BaseModel
    {
        T Get(int id);
        PagedList<T> Filter(int pageIndex, int pageSize, Expression<Func<T, bool>> predicate);
        int Create(T newItem);
        void Update(T item);
        void Delete(int id);
    }
}
