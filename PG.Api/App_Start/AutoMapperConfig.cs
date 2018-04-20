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
                config.CreateMap<SiteDto, Site>().ReverseMap();
            });
        }
    }
}