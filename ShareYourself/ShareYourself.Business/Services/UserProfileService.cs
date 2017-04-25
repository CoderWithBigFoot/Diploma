using ShareYourself.Data;
using ShareYourself.Data.Entities;
using AutoMapper;

namespace ShareYourself.Business.Services
{
    public class UserProfileService : BaseService, IUserProfileService
    {
        public UserProfileService(IShareYourselfUow uow) : base(uow) { }

        public virtual void Create<TDto>(TDto dto)
            where TDto: class
        {
            var userProfile = Mapper.Map<UserProfile>(dto);
            _uow.UserProfileRepository.Add(userProfile);
            _uow.Commit();
        }
    }
}
