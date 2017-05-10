using System.Collections.Generic;
using ShareYourself.Business.Dto;

namespace ShareYourself.Business
{
    public interface IUserPostService : IBaseServiceOperations
    {
        new void Create<TDto>(TDto dto) where TDto : UserPostCreationDto;
        IEnumerable<UserPostDto> Take(int userId, int skip, int count);
        IEnumerable<UserPostDto> Take(TagDto tagDto, int skip, int count);
        IEnumerable<UserPostDto> Take(PostFilters filter, int userId, int skip, int count);
             
        int Likes(int postId);
        void SetLike(int userId, int postId);
    }
}
