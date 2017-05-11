using ShareYourself.Business.Dto;
using ShareYourself.Data.Entities;
using AutoMapper;

namespace ShareYourself.Business.Infrastructure.MapperProfiles
{
    public class UserProfileMapperProfile : Profile
    {
        public UserProfileMapperProfile()
        {
            CreateMap<UserProfile, UserProfileDto>()
                .ForMember(x => x.Posts, opt => opt.MapFrom(x => x.Publications.Count))
                .ForMember(x => x.Subscribtions, opt => opt.MapFrom(x => x.Subscriptions.Count));
            CreateMap<UserProfileDto, UserProfile>();

            CreateMap<UserProfile, UserProfileRegistrationDto>();
            CreateMap<UserProfileRegistrationDto, UserProfile>();

            CreateMap<UserProfile, UserProfileEditingDto>();
            CreateMap<UserProfileEditingDto, UserProfile>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            CreateMap<UserProfile, UserProfileIdDto>();
            CreateMap<UserProfile, UserProfileAvatarIdDto>();

            CreateMap<UserProfile, UserProfileInfoForPostDto>();


            CreateMap<UserImage, UserImageDto>();
        }
    }
}
