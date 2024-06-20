using AutoMapper;
using FiorelloAppApi.DTOs;
using FiorelloAppApi.Models;

namespace FiorelloAppApi.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Slider, SliderDto>();
            CreateMap<SliderCreateDto, Slider>();
            CreateMap<SliderEditDto, Slider>();
        }
    }
}
