using AutoMapper;
using Station.Common.Mapper;
using Station.Models;

namespace Station.Common
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Refuelling, RefuellingDTO>().ReverseMap();
        }
    }
}