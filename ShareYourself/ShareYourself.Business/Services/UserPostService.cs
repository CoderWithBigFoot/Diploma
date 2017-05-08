using System.Linq;
using System.Collections.Generic;
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

        public TDto Get<TDto>(int id)
            where TDto : class
        {
            var resultDto = uow
                .UserPostsRepository
                .Get<TDto>(x => x.Id == id)
                .FirstOrDefault();

            return resultDto;
        }

        public IEnumerable<UserPostDto> Take(int userId, int skip, int count)
        {
            var result = uow
                .UserPostsRepository
                .Get<UserPostDto>(x => x.CreatorId == userId)
                .OrderByDescending(x=>x.Id)
                .Skip(skip)
                .Take(count);

            return result;
        }

        public IEnumerable<UserPostDto> Take(TagDto tagDto, int skip, int count)
        {
            var tag = uow.TagsRepository.Get(x => x.Name == tagDto.Name).FirstOrDefault();
            if (tag == null) { return null; }

            var result = uow
                .UserPostsRepository
                .Get<UserPostDto>(x => x.Tags.Contains(tag))
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(count);

            return result;
        }

        public int Likes(int postId)
        {
            return uow
                .UserPostsRepository
                .Get(x => x.Id == postId)
                .FirstOrDefault()
                .Likes
                .Count;
        }

        public void SetLike(int userId, int postId)
        {
                var likers = uow
                    .UserPostsRepository
                    .Get(x => x.Id == postId)
                    .FirstOrDefault()
                    .Likes;

            var user = uow
                    .UserProfilesRepository
                    .Get(x => x.Id == userId)
                    .FirstOrDefault();

            if (likers.Contains(user))
            {
                likers.Remove(user);
            }
            else
            {
                likers.Add(user);
            }

            uow.Commit();
        }
    }
}
