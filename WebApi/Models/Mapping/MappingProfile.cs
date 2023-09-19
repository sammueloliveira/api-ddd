using AutoMapper;
using Domain.Entities;

namespace WebApi.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MessageViewModel, Message>().ReverseMap();
        }
    }
}
