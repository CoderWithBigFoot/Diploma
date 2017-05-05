using System.Linq;
using ShareYourself.Data;
using ShareYourself.Data.Entities;
using ShareYourself.Business.Dto;
using AutoMapper;

namespace ShareYourself.Business.Services
{
    public class UserPostService : BaseService, IUserPostService
    {
        private ITagService _tagService;

        public UserPostService(IShareYourselfUow uow, ITagService tagService) : base(uow)
        {
            _tagService = tagService;
        }

        void IBaseOperations.Create<TDto>(TDto dto)
        {
            var userPost = Mapper.Map<UserPost>(dto);
            uow.UserPostsRepository.Add(userPost);
            uow.Commit();
        }

        void IUserPostService.Create<TDto>(TDto dto)
        {
            var userPost = Mapper.Map<UserPost>(dto);
            Tag tag;
            
            foreach(var tagDto in dto.Tags)
            {
                if (!_tagService.Contains(tagDto.Name))
                {
                    _tagService.Create(tagDto);
                }

                tag = uow.TagsRepository.Get(x => x.Name == tagDto.Name).FirstOrDefault();
                if(tag != null)
                {
                    userPost.Tags.Add(tag);
                }
            }
               
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
