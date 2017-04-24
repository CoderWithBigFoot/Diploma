using ShareYourself.Business.Dto;

namespace ShareYourself.Business
{
    public interface IUserProfileService
    {
        void Create(UserProfileDto dto);
    }
}
