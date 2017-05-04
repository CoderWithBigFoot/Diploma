using ShareYourself.Business.Dto;
using ShareYourself.Data.Entities;
using AutoMapper;

namespace ShareYourself.Business.Infrastructure.MapperProfiles
{
    public class UserPostMapperProfile : Profile
    {
        public UserPostMapperProfile()
        {
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();

            CreateMap<UserPost, UserPostCreationDto>();
            CreateMap<UserPostCreationDto, UserPost>();

            CreateMap<UserPost, UserPostDto>();
            CreateMap<UserPostDto, UserPost>();
        }
    }
}
