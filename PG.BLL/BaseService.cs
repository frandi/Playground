using PG.Model;
using PG.Repository;
using System;

namespace PG.BLL
{
    public abstract class BaseService<TEntity, TRepository> 
        where TEntity: BaseModel
        where TRepository: IRepository<TEntity>
    {
        protected TRepository Repo;

        protected BaseService(TRepository repository)
        {
            Repo = repository;
        }

        public int Create(TEntity newItem)
        {
            newItem.Created = DateTime.UtcNow;
            return Repo.Create(newItem);
        }

        public void Delete(int id)
        {
            Repo.Delete(id);
        }

        public TEntity GetById(int id)
        {
            return Repo.Get(id);
        }

        public void Update(TEntity item)
        {
            item.Updated = DateTime.UtcNow;
            Repo.Update(item);
        }
    }
}
