using GenericRepository.Data;
using GenericRepository.Data.EntityFramework;
using ShareYourself.Data.Entities;

namespace ShareYourself.Data
{
    public interface IShareYourselfUow : IUnitOfWork
    {
        Repository<UserProfile> UserProfileRepository { get; }
        Repository<UserImage> UserImagesRepository { get; }
    }
}
