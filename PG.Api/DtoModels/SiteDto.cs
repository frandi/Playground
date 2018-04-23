using AutoMapper;
using PG.Model;

namespace PG.Api.DtoModels
{
    public class NewSiteDto : BaseNewDto<Site>
    {
        public string Name { get; set; }

        public override Site ToEntity()
        {
            return Mapper.Map<NewSiteDto, Site>(this);
        }
    }

    public class EditSiteDto : BaseDto<Site>
    {
        public string Name { get; set; }

        public override Site ToEntity(Site originalEntity)
        {
            var updatedEntity = originalEntity;

            Mapper.Map(this, updatedEntity);

            return updatedEntity;
        }
    }

    public class SiteDto : EditSiteDto
    {
        public override Site ToEntity()
        {
            return Mapper.Map<SiteDto, Site>(this);
        }

        public override void LoadFromEntity(Site entity)
        {
            base.LoadFromEntity(entity);

            Name = entity.Name;
        }
    }
}