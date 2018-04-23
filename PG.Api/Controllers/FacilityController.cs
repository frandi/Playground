using PG.Api.DtoModels;
using PG.BLL;
using PG.Model;
using System.Web.Http;

namespace PG.Api.Controllers
{
    [RoutePrefix("Facility")]
    public class FacilityController : BaseController<NewFacilityDto, FacilityDto, FacilityDto, Facility, IFacilityService>
    {
        public FacilityController(IFacilityService service) : base(service)
        {
        }

        [Route("{id}", Name = "GetFacilityById")]
        public override IHttpActionResult Get(int id)
        {
            return base.Get(id);
        }
    }
}