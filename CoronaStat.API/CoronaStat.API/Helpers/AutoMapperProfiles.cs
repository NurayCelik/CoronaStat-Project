using AutoMapper;
using CoronaStat.API.Dtos;
using CoronaStat.API.Models;
using System.Linq;


namespace CoronaStat.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Country, CountryForListDto>()
               .ForMember(dest => dest.Vaka, opt =>
               {
                   opt.MapFrom(src => src.Values.FirstOrDefault().Vaka);
               }
               );
        
            CreateMap<Value, WorldForDto>().ReverseMap();
            CreateMap<Photo, PhotoForCreationDto>().ReverseMap();
            CreateMap<PhotoForReturnDto, Photo>().ReverseMap();
            CreateMap<Value, WorldForListDto>().ReverseMap();
            CreateMap<Photo, PhotoForDto>().ReverseMap(); ;


        }
    }
}