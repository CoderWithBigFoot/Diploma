using AutoMapper;
using ShareYourself.Business.Dto;
using ShareYourself.WebUI.Models;

namespace ShareYourself.WebUI.Infrastructure.MapperProfiles
{
    public class UserProfileDtosViewModelProfile : Profile
    {
        public UserProfileDtosViewModelProfile()
        {
            CreateMap<UserProfileRegistrationDto, RegisterViewModel>();
            CreateMap<RegisterViewModel, UserProfileRegistrationDto>();
        }
    }
}