using PG.Model;
using System.Data.Entity;

namespace PG.DataAccess
{
    public class PlaygroundDbContext : DbContext, IPlaygroundDbContext
    {
        public PlaygroundDbContext() : base("DefaultConnection")
        {
            
        }

        public PlaygroundDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }

        public DbSet<Site> Sites { get; set; }
        
    }
}
