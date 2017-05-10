using ShareYourself.Business.Dto;

namespace ShareYourself.Business
{
    public interface IUserProfileService : IBaseServiceOperations
    {
        TDto Get<TDto>(string email) where TDto : class;
        void Update(UserProfileEditingDto dto);
        void Update(UserProfileAvatarEditingDto dto);

        void Subscribe(int userId, int toId);
        bool IsSubscribedOn(int userId, int toId);     
    }
}
