using PG.DataAccess;
using PG.Model;

namespace PG.Repository
{
    public class FacilityRepository : BaseRepository<Facility>, IFacilityRepository
    {
        public FacilityRepository(IPlaygroundDbContext dbContext) : base(dbContext)
        {
        }
    }
}
