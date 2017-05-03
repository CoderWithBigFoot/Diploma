using ShareYourself.Business.Dto;
using ShareYourself.Data.Entities;
using AutoMapper;

namespace ShareYourself.Business.Infrastructure.MapperProfiles
{
    public class UserProfileMapperProfile : Profile
    {
        public UserProfileMapperProfile()
        {
            // Try to get an AvatarId from UserProfile and after that, if not null, create the request to the UserImages table to extract the needed avatar
            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserProfileDto, UserProfile>();

            CreateMap<UserProfile, UserProfileRegistrationDto>();
            CreateMap<UserProfileRegistrationDto, UserProfile>();

            CreateMap<UserProfile, UserProfileEditingDto>();
            CreateMap<UserProfileEditingDto, UserProfile>()
                .ForMember(m => m.Id, opt => opt.Ignore());

            CreateMap<UserProfile, UserProfileIdDto>();
            CreateMap<UserProfile, UserProfileAvatarIdDto>();

            CreateMap<UserImage, UserImageDto>();


        }
    }
}
