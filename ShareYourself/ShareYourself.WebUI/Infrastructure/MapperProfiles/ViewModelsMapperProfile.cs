using AutoMapper;
using ShareYourself.Business.Dto;
using ShareYourself.WebUI.Models;
using ShareYourself.Business;

namespace ShareYourself.WebUI.Infrastructure.MapperProfiles
{
    public class ViewModelsMapperProfile : Profile
    {
        private IUserPostService _userPostService;

        public ViewModelsMapperProfile(IUserPostService service)
        {
            _userPostService = service;
        }

        public ViewModelsMapperProfile()
        {
            CreateMap<UserProfileRegistrationDto, RegisterViewModel>();
            CreateMap<RegisterViewModel, UserProfileRegistrationDto>();

            CreateMap<UserProfileEditingDto, UserProfileEditingViewModel>();
            CreateMap<UserProfileEditingViewModel, UserProfileEditingDto>();

            CreateMap<UserProfileDto, UserProfileHomeViewModel>();
            CreateMap<UserProfileHomeViewModel, UserProfileDto>();

            CreateMap<UserProfileInfoForPostDto, UserProfileInfoForPostViewModel>();

            CreateMap<UserPostDto, UserPostViewModel>()
                .ForMember(x => x.Likes, opt => opt.MapFrom(x => _userPostService.LikesCount(x.Id)));
        }
    }
}