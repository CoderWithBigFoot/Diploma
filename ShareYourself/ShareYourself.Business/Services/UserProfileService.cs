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

        private void CheckNull(object obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException();
            }
        }

        private UserProfile Get(int userId)
        {
            return uow
                .UserProfilesRepository
                .Get(x => x.Id == userId)
                .FirstOrDefault();
        }

        public void Create<TDto>(TDto dto)
            where TDto: class
        {
            var userProfile = Mapper.Map<UserProfile>(dto);
            uow.UserProfilesRepository.Add(userProfile);
            uow.Commit();
        }

        public TDto Get<TDto>(int id)
            where TDto : class
        {           
                var resultDto = uow.UserProfilesRepository
                    .Get<TDto>(x => x.Id == id)
                    .FirstOrDefault();

            return resultDto;            
        }

        public TDto Get<TDto>(string email)
            where TDto : class
        {
            var resultDto = uow.UserProfilesRepository
                .Get<TDto>(x => x.Email == email)
                .FirstOrDefault();

            return resultDto;
        }

        public void Update(UserProfileEditingDto userProfileDto)
        {
            CheckNull(userProfileDto);

            var updatingUserProfile = uow
                .UserProfilesRepository
                .Get(x => x.Id == userProfileDto.Id)
                .FirstOrDefault();

            CheckNull(updatingUserProfile);

            updatingUserProfile = Mapper.Map(userProfileDto, updatingUserProfile);
            uow.Commit();
        }

        public void Update(UserProfileAvatarEditingDto dto)
        {
            CheckNull(dto);

            var updatingUserProfile = uow
                .UserProfilesRepository
                .Get(x => x.Id == dto.UserProfileId)
                .FirstOrDefault();

            CheckNull(updatingUserProfile);

            if(dto.Content == null)
            {
                updatingUserProfile.Avatar = null;
                if(updatingUserProfile.Avatar.Owners.Count == 0)
                {
                    uow.UserImagesRepository.Remove(updatingUserProfile.Avatar);
                }
                uow.Commit();
                return;
            }

            UserImage avatar;

            if(updatingUserProfile.Avatar == null)
            {
                avatar = new UserImage();
                avatar.MimeType = dto.MimeType;
                avatar.Content = dto.Content;
                // avatar.Creator = updatingUserProfile;
                updatingUserProfile.Avatar = avatar;
                uow.Commit();
                return;
            }
            avatar = updatingUserProfile.Avatar;
            avatar.MimeType = dto.MimeType;
            avatar.Content = dto.Content;

            uow.Commit();
        }

        public void Subscribe(int userId, int toId) // Add subscription if doesn't exist, remove if exists
        {
            if(IsSubscribedOn(userId, toId))
            {
                Get(userId)
                     .Subscriptions.Remove(Get(toId));
            }
            else
            {
                Get(userId)
                    .Subscriptions.Add(Get(toId));
            }
            uow.Commit();
        }

        public bool IsSubscribedOn(int userId, int toId)
        {
          return Get(userId)
                .Subscriptions
                .Select(x => x.Id)
                .Contains(toId);
        }
    }
}
