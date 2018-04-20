using PG.Common;
using PG.Model;

namespace PG.BLL
{
    public interface ISiteService : IService<Site>
    {
        PagedList<Site> GetByName(string name, int pageIndex = 1, int pageSize = 20);
    }
}
