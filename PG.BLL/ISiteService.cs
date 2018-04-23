using PG.Common;
using PG.Model;

namespace PG.BLL
{
    public interface ISiteService : IService<Site>
    {
        PagedList<Site> GetByName(string name, int pageIndex = 1, int pageSize = 20);
        PagedList<Facility> GetFacilities(int siteId, int pageIndex = 1, int pageSize = 20);
        void AddFacility(int siteId, Facility newFacility);
    }
}
