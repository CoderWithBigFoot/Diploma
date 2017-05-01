using System;
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

            CreateMap<UserProfile, UserProfileIdDto>();

            CreateMap<UserProfile, UserProfileAvatarDto>()
                .ConstructUsing(x => {
                    if (x.Avatar == null)
                    {
                        return null;
                    }
                    else
                    {
                        return new UserProfileAvatarDto
                        {
                            Content = x.Avatar.Content,
                            MimeType = x.Avatar.MimeType,
                            UserProfileId = x.Id
                        };
                    }
                });
        
                /*.ForMember(x => x.UserProfileId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Avatar.Content))
                .ForMember(x => x.MimeType, opt => opt.MapFrom(x => x.Avatar.MimeType));*/                
        }
    }
}
