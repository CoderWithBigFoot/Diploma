using System.Linq;
using ShareYourself.Data;
using ShareYourself.Data.Entities;
using AutoMapper;

namespace ShareYourself.Business.Services
{
    public class UserPostService : BaseService, IUserPostService
    {
        public UserPostService(IShareYourselfUow uow) : base(uow) { }

        public virtual void Create<TDto>(TDto dto)
            where TDto : class
        {
            var userPost = Mapper.Map<UserPost>(dto);
            uow.UserPostsRepository.Add(userPost);
            uow.Commit();
        }

        public virtual TDto Get<TDto>(int id)
            where TDto : class
        {
            var resultDto = uow
                .UserPostsRepository
                .Get<TDto>(x => x.Id == id)
                .FirstOrDefault();

            return resultDto;
        }
    }
}
