using AutoMapper;
using CastlesToWatch.API.Model.Domain;
using CastlesToWatch.API.Model.DTO;

namespace CastlesToWatch.API.Mappings
{
    public class AutoMapperProfiles : Profile 
    {
        public AutoMapperProfiles()
        {
            CreateMap<Country,CountryDTO>().ReverseMap();
            CreateMap<CreateCountryDto, Country>().ReverseMap();
            CreateMap<Castle,CastleDTO>().ReverseMap();
            CreateMap<CreateCastleDto, Castle>().ReverseMap();
            CreateMap<UpdateCastleDTO, Castle>().ReverseMap();




        }
    }
}
