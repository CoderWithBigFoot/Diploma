using System;
using System.IO;
using System.Collections;
using ShareYourself.Business.Dto;
using ShareYourself.Data.Entities;
using AutoMapper;
using AutoMapper.XpressionMapper;

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

            CreateMap<UserProfile, UserProfileIdDto>();
            CreateMap<UserProfile, UserProfileAvatarIdDto>();

            CreateMap<UserImage, UserImageDto>();
        }
    }
}
