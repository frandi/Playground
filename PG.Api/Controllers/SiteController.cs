using PG.Api.DtoModels;
using PG.BLL;
using PG.Common;
using PG.Model;
using System.Linq;
using System.Web.Http;

namespace PG.Api.Controllers
{
    [RoutePrefix("Site")]
    public class SiteController : BaseController<NewSiteDto, EditSiteDto, SiteDto, Site, ISiteService>
    {
        public SiteController(ISiteService siteService)
            : base(siteService)
        {
            
        }

        [Route("{id}", Name = "GetById")]
        public override IHttpActionResult Get(int id)
        {
            return base.Get(id);
        }

        [Route("")]
        public override IHttpActionResult Post([FromBody] NewSiteDto value)
        {
            return base.Post(value);
        }

        [Route("{id}")]
        public override IHttpActionResult Put(int id, [FromBody] EditSiteDto value)
        {
            return base.Put(id, value);
        }

        [Route("{id}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        [Route("n/{name}", Name = "GetByName")]
        public IHttpActionResult Get(string name)
        {
            var list = Svc.GetByName(name);

            var source = list.Items.Select(i =>
            {
                var item = new SiteDto();
                item.LoadFromEntity(i);

                return item;
            });

            return Json(new PagedList<SiteDto>(source, list.PageIndex, list.PageSize, list.TotalCount));
        }

        
    }
}