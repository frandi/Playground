using PG.DataAccess;
using PG.Model;

namespace PG.Repository
{
    public class SiteRepository : BaseRepository<Site>, ISiteRepository
    {
        public SiteRepository(IPlaygroundDbContext dbContext)
            : base(dbContext)
        {

        }
        
    }
}
