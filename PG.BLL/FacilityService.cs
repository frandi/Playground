using PG.Model;
using PG.Repository;

namespace PG.BLL
{
    public class FacilityService : BaseService<Facility, IFacilityRepository>, IFacilityService
    {
        public FacilityService(IFacilityRepository repository) : base(repository)
        {
        }
    }
}
