using AutoMapper;
using PG.Api.DtoModels;
using PG.Model;

namespace PG.Api
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<NewSiteDto, Site>();
                config.CreateMap<EditSiteDto, Site>();
                config.CreateMap<SiteDto, Site>().ReverseMap();
            });
        }
    }
}