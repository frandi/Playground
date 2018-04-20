using PG.Common;
using PG.Model;
using PG.Repository;

namespace PG.BLL
{
    public class SiteService : BaseService<Site, ISiteRepository>, ISiteService
    {
        public SiteService(ISiteRepository siteRepository)
            : base(siteRepository)
        {
        
        }
        
        public PagedList<Site> GetByName(string name, int pageIndex = 1, int pageSize = 20)
        {
            return Repo.Filter(pageIndex, pageSize, item => item.Name.Contains(name));
        }
    }
}
