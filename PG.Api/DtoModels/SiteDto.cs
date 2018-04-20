using AutoMapper;
using PG.Model;

namespace PG.Api.DtoModels
{
    public class SiteDto
    {
        public SiteDto()
        {

        }

        public SiteDto(Site site)
        {
            Id = site.Id;
            Name = site.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public Site ToSite()
        {
            return Mapper.Map<SiteDto, Site>(this);
        }
    }
}