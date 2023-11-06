using AutoMapper;
using MarvelApi.Dtos;
using MarvelApi.Modals;

namespace MarvelApi.Mappings
{
    public class HeroiMapping : Profile
    {
        public HeroiMapping() 
        { 
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));
            CreateMap<HeroiResponse, HeroiModal>();
            CreateMap<HeroiModal, HeroiResponse>();
        }
    }
}
