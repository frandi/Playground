using PG.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.DataAccess
{
    public class PlaygroundDbContext : DbContext, IPlaygroundDbContext
    {
        public DbSet<Site> Sites { get; set; }
        
    }
}
