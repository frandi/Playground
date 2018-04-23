using PG.Model;
using PG.Repository;

namespace PG.BLL
{
    public class FacilityService : BaseService<Facility, IFacilityRepository>, IFacilityService
    {
        public FacilityService(IFacilityRepository repository) : base(repository)
        {
        }

        public override Facility GetById(int id)
        {
            return Repo.Get(id, facility => facility.Site);
        }
    }
}
