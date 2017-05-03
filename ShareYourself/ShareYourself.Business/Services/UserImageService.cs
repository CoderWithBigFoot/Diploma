using System;
using System.Linq;
using ShareYourself.Data;
using ShareYourself.Data.Entities;
using AutoMapper;
using ShareYourself.Business.Dto;

namespace ShareYourself.Business.Services
{
    public class UserImageService : BaseService, IUserImageService
    {
        public UserImageService(IShareYourselfUow uow) : base(uow) { }

        public virtual void Create<TDto>(TDto dto)
            where TDto : class
        {
            var userImage = Mapper.Map<UserImage>(dto);
            uow.UserImagesRepository.Add(userImage);
            uow.Commit();
        }

        public virtual TDto Get<TDto>(int id)
            where TDto : class
        {
            var userImageDto = uow
                .UserImagesRepository
                .Get<TDto>(x => x.Id == id)
                .FirstOrDefault();

            return userImageDto;
        }
    }
}
