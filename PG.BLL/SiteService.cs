using System;
using PG.Common;
using PG.Model;
using PG.Repository;

namespace PG.BLL
{
    public class SiteService : BaseService<Site, ISiteRepository>, ISiteService
    {
        private readonly IFacilityRepository _facilityRepository;

        public SiteService(ISiteRepository siteRepository, IFacilityRepository facilityRepository)
            : base(siteRepository)
        {
            _facilityRepository = facilityRepository;
        }

        public void AddFacility(int siteId, Facility newFacility)
        {
            newFacility.Created = DateTime.UtcNow;
            
            var site = Repo.Get(siteId, s => s.Facilities);
            site?.Facilities.Add(newFacility);

            Repo.Update(site);
        }
        
        public PagedList<Site> GetByName(string name, int pageIndex = 1, int pageSize = 20)
        {
            return Repo.Filter(pageIndex, pageSize,
                new OrderBySelector<Site, string>(OrderByType.Ascending, site => site.Name),
                site => site.Name.Contains(name));
        }

        public PagedList<Facility> GetFacilities(int siteId, int pageIndex = 1, int pageSize = 20)
        {
            return _facilityRepository.Filter(pageIndex, pageSize,
                new OrderBySelector<Facility, string>(OrderByType.Ascending, facility => facility.Name),
                facility => facility.SiteId == siteId);
        }
    }
}
