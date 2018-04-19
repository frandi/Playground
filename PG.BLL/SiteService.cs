using PG.Common;
using PG.Model;
using PG.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.BLL
{
    public class SiteService
    {
        private ISiteRepository _siteRepository;

        public SiteService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public Site GetById(int id)
        {
            return _siteRepository.Get(id);
        }

        public PagedList<Site> GetByName(string name, int pageIndex = 0, int pageSize = 20)
        {
            return _siteRepository.Filter(pageIndex, pageSize, item => item.Name.Contains(name));
        }
    }
}
