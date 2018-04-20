using AutoMapper;
using PG.Model;

namespace PG.Api.DtoModels
{
    public class NewSiteDto
    {
        public string Name { get; set; }

        public virtual Site ToSite()
        {
            return Mapper.Map<NewSiteDto, Site>(this);
        }
    }

    public class EditSiteDto : NewSiteDto
    {
        public int Id { get; set; }

        public Site ToSite(Site originaValue)
        {
            var updatedValue = originaValue;

            Mapper.Map(this, updatedValue);

            return updatedValue;
        }
    }

    public class SiteDto : EditSiteDto
    {
        public SiteDto()
        {

        }

        public SiteDto(Site site)
        {
            Id = site.Id;
            Name = site.Name;
        }
        
        public override Site ToSite()
        {
            return Mapper.Map<SiteDto, Site>(this);
        }
    }
}