using ShareYourself.Business.Dto;

namespace ShareYourself.Business
{
    public interface IUserPostService : IBaseOperations
    {
       new void Create<TDto>(TDto dto) where TDto : UserPostCreationDto;
    }
}
