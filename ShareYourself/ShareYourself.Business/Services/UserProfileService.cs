using ShareYourself.Business.Dto;
using ShareYourself.Data;
using ShareYourself.Data.Entities;
using AutoMapper;

namespace ShareYourself.Business.Services
{
    public class UserProfileService : BaseService, IUserProfileService<UserProfileDto>
    {
        public UserProfileService(IShareYourselfUow uow) : base(uow) { }

        public void Create(UserProfileDto userDto)
        {
            var result = Mapper.Map<UserProfile>(userDto);
            _uow.UserProfileRepository.Add(result);
            _uow.Commit();
        }
    }
}
