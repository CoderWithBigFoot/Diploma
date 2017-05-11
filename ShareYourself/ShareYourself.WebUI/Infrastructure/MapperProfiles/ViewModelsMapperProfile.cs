using AutoMapper;
using ShareYourself.Business.Dto;
using ShareYourself.WebUI.Models;

namespace ShareYourself.WebUI.Infrastructure.MapperProfiles
{
    public class ViewModelsMapperProfile : Profile
    {
        public ViewModelsMapperProfile()
        {
            CreateMap<UserProfileRegistrationDto, RegisterViewModel>();
            CreateMap<RegisterViewModel, UserProfileRegistrationDto>();
            CreateMap<UserProfileEditingDto, UserProfileEditingViewModel>();
            CreateMap<UserProfileEditingViewModel, UserProfileEditingDto>();
            CreateMap<UserProfileDto, UserProfileHomeViewModel>();
            CreateMap<UserProfileHomeViewModel, UserProfileDto>();
            CreateMap<UserProfileInfoForPostDto, UserProfileInfoForPostViewModel>();
            CreateMap<UserPostDto, UserPostViewModel>();
            CreateMap<UserProfileSubscriptionInfoDto, SubscriptionInfoViewModel>();               
        }
    }
}