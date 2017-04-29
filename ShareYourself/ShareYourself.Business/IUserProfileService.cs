using ShareYourself.Business.Dto;

namespace ShareYourself.Business
{
    public interface IUserProfileService : IBaseOperations
    {
        TDto Get<TDto>(string email) where TDto : class;
        void Update(UserProfileEditingDto dto);
    }
}
