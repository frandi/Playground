using PG.Common;
using PG.Model;
using PG.Repository;

namespace PG.BLL
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;

        public SiteService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public int Create(Site newItem)
        {
            return _siteRepository.Create(newItem);
        }

        public void Delete(int id)
        {
            _siteRepository.Delete(id);
        }

        public Site GetById(int id)
        {
            return _siteRepository.Get(id);
        }

        public PagedList<Site> GetByName(string name, int pageIndex = 1, int pageSize = 20)
        {
            return _siteRepository.Filter(pageIndex, pageSize, item => item.Name.Contains(name));
        }

        public void Update(Site item)
        {
            _siteRepository.Update(item);
        }
    }
}
