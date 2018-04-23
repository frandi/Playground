using System.Data.Entity.Spatial;
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

                config.CreateMap<NewFacilityDto, Facility>()
                    .ForMember(d => d.Location, opt => opt.MapFrom(s => DbGeography.FromText(s.Location.AsText())));
                config.CreateMap<FacilityDto, Facility>().ReverseMap();
            });
        }
    }
}