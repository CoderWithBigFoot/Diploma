using ShareYourself.Business.Dto;
using ShareYourself.Data.Entities;
using AutoMapper;

namespace ShareYourself.Business.Infrastructure.MapperProfiles
{
    public class UserProfileMapperProfile : Profile
    {
        public UserProfileMapperProfile()
        {
            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserProfileDto, UserProfile>();

            CreateMap<UserProfile, UserProfileRegistrationDto>();
            CreateMap<UserProfileRegistrationDto, UserProfile>();

            CreateMap<UserProfile, UserProfileEditingDto>();
            CreateMap<UserProfileEditingDto, UserProfile>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}
