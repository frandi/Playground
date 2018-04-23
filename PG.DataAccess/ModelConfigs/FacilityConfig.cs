using PG.Model;
using System.Data.Entity;

namespace PG.DataAccess.ModelConfigs
{
    public static class FacilityConfig
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facility>()
                .HasRequired(facility => facility.Site)
                .WithMany(site => site.Facilities)
                .HasForeignKey(facility => facility.SiteId);
        }
    }
}
