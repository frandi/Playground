using PG.Api.DtoModels;
using PG.BLL;
using PG.Common;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace PG.Api.Controllers
{
    [RoutePrefix("Site")]
    public class SiteController : ApiController
    {
        private readonly ISiteService _siteService;

        public SiteController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [Route("n/{name}", Name = "GetByName")]
        public IHttpActionResult Get(string name)
        {
            var list = _siteService.GetByName(name);

            return Json(new PagedList<SiteDto>(list.Select(i => new SiteDto(i)), list.PageIndex, list.PageSize, list.TotalCount));
        }

        [Route("{id}", Name = "GetById")]
        public IHttpActionResult Get(int id)
        {
            var item = _siteService.GetById(id);
            if (item == null)
                return NotFound();

            return Ok(new SiteDto(item));
        }
        
        [Route("")]
        public IHttpActionResult Post([FromBody]NewSiteDto value)
        {
            var site = value.ToSite();
            var id = _siteService.Create(site);
            
            return CreatedAtRoute("GetById", new {id}, new SiteDto(site));
        }
        
        [Route("{id}")]
        public IHttpActionResult Put(int id, [FromBody]EditSiteDto value)
        {
            if (id != value.Id)
                return BadRequest();

            var originalValue = _siteService.GetById(id);
            var site = value.ToSite(originalValue);

            _siteService.Update(site);

            return Ok(new SiteDto(site));
        }
        
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            _siteService.Delete(id);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}