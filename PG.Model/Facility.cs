// TODO: change this reference into "System.Data.Spatial" which is the built-in .Net Framework library. 
// We need to make this project to be ORM agnostic in the future. However, it isn't possible for now because it doesn't play nice with EF.
using System.Data.Entity.Spatial;

namespace PG.Model
{
    public class Facility : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Images { get; set; }
        public DbGeography Location { get; set; }

        public int SiteId { get; set; }
        public Site Site { get; set; }
    }
}
