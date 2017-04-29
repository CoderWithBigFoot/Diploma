using System;
using System.Linq;
using ShareYourself.Data;
using ShareYourself.Data.Entities;
using AutoMapper;
using ShareYourself.Business.Dto;

namespace ShareYourself.Business.Services
{
    public class UserProfileService : BaseService, IUserProfileService
    {
        public UserProfileService(IShareYourselfUow uow) : base(uow) { }

        public virtual void Create<TDto>(TDto dto)
            where TDto: class
        {
            var userProfile = Mapper.Map<UserProfile>(dto);
            uow.UserProfileRepository.Add(userProfile);
            uow.Commit();
        }

        public virtual TDto Get<TDto>(int id)
            where TDto : class
        {
            var userProfile = uow.UserProfileRepository
                .Get<TDto>(x => x.Id == id)
                .FirstOrDefault();
            return userProfile;
        }

        public virtual TDto Get<TDto>(string email)
            where TDto : class
        {
            var userProfile = uow.UserProfileRepository
                .Get<TDto>(x => x.Email == email)
                .FirstOrDefault();

            return userProfile;
        }

        public virtual void Update(UserProfileEditingDto userProfileDto)
        {
            if (userProfileDto == null)
            {
                throw new ArgumentNullException();
            }

            var updatingUserProfile = uow
                .UserProfileRepository
                .Get(x => x.Id == userProfileDto.Id)
                .FirstOrDefault();

            if(updatingUserProfile == null)
            {
                throw new ArgumentNullException();
            }

            updatingUserProfile = Mapper.Map(userProfileDto, updatingUserProfile);
            uow.Commit();
        }
    }
}
