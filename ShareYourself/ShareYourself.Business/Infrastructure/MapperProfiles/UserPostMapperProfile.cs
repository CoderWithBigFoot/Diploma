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
            CreateMap<UserPostCreationDto, UserPost>()
                .ForMember(x => x.Tags, opt => opt.Ignore());

            CreateMap<UserPost, UserPostDto>();
            CreateMap<UserPostDto, UserPost>();

            CreateMap<TagDto, string>()
                .ConvertUsing(x => x.Name);
        }
    }
}
