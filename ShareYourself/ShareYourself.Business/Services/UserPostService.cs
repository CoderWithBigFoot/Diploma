using System.Linq;
using System.Collections.Generic;
using ShareYourself.Data;
using ShareYourself.Data.Entities;
using ShareYourself.Business.Dto;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace ShareYourself.Business.Services
{
    public class UserPostService : BaseService, IUserPostService
    {
        private ITagService _tagService;

        private IEnumerable<UserPostDto> TakeFresh(int userId, int skip, int count)
        {
            return uow
                .UserPostsRepository
                .Get<UserPostDto>()
                .Where(x => x.CreatorId != userId)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(count);
        }

        private IEnumerable<UserPostDto> TakeUpdates(int userId, int skip, int count)
        {
            return uow
                .UserProfilesRepository
                .Get(x => x.Id == userId)
                .FirstOrDefault()
                .Subscriptions
                .SelectMany(x => x.Publications)
                .OrderByDescending(x => x.Id)
                .Skip(skip)
                .Take(count)
                .AsQueryable()
                .ProjectTo<UserPostDto>();
        }

        private IEnumerable<UserPostDto> TakeLiked(int userId, int skip, int count)
        {
            return uow
                .UserProfilesRepository
                .Get(x => x.Id == userId)
                .FirstOrDefault()
                .Likes
                .Skip(skip)
                .Take(count)
                .AsQueryable()
                .ProjectTo<UserPostDto>();
        }

        public UserPostService(IShareYourselfUow uow, ITagService tagService) : base(uow)
        {
            _tagService = tagService;
        }

        void IBaseServiceOperations.Create<TDto>(TDto dto)
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

        public IEnumerable<UserPostDto> Take(PostFilters filter, int userId, int skip, int count)
        {
            switch (filter)
            {
                case PostFilters.Fresh: return TakeFresh(userId, skip, count);
                case PostFilters.Updates: return TakeUpdates(userId, skip, count);
                case PostFilters.Liked: return TakeLiked(userId, skip, count);
                default: return Enumerable.Empty<UserPostDto>();
            }
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
