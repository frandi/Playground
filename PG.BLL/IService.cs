using PG.Model;

namespace PG.BLL
{
    public interface IService<TEntity> where TEntity : BaseModel
    {
        TEntity GetById(int id);
        int Create(TEntity newItem);
        void Update(TEntity item);
        void Delete(int id);
    }
}
