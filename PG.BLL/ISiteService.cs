using PG.Common;
using PG.Model;

namespace PG.BLL
{
    public interface ISiteService
    {
        Site GetById(int id);
        PagedList<Site> GetByName(string name, int pageIndex = 1, int pageSize = 20);
        int Create(Site newItem);
        void Update(Site item);
        void Delete(int id);
    }
}
