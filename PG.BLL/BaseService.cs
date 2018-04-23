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

        public int Create(TEntity newEntity)
        {
            newEntity.Created = DateTime.UtcNow;
            return Repo.Create(newEntity);
        }

        public void Delete(int id)
        {
            Repo.Delete(id);
        }

        public TEntity GetById(int id)
        {
            return Repo.Get(id);
        }
        
        public void Update(TEntity entity)
        {
            entity.Updated = DateTime.UtcNow;
            Repo.Update(entity);
        }
    }
}
