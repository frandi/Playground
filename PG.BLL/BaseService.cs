using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG.Common;
using PG.Model;
using PG.Repository;

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
            Repo.Update(item);
        }
    }
}
