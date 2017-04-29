using System.Linq;
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

        public virtual TDto Get<TDto>(int id)
            where TDto : class
        {
            var userProfile = _uow.UserProfileRepository
                .Get<TDto>(x => x.Id == id)
                .FirstOrDefault();
            return userProfile;
        }

        public virtual TDto Get<TDto>(string email)
            where TDto : class
        {
            var userProfile = _uow.UserProfileRepository
                .Get<TDto>(x => x.Email == email)
                .FirstOrDefault();

            return userProfile;
        }
    }
}
