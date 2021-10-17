using AutoMapper;
using HousingSystem.DomainLayer.Entities;
using HousingSystem.Dto.Apartment;

namespace HousingSystem.WebApi.Extensions.MappingProfiler
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            //CreateMap<Model, ModelResourse>();
            CreateMap<CreateBuildingDto, Apartment>();
        }
    }
}
