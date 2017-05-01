using System.Data.Entity;
using GenericRepository.Data.EntityFramework;
using ShareYourself.Data.Entities;

namespace ShareYourself.Data
{
    public class ShareYourselfUow : UnitOfWork, IShareYourselfUow
    {
        protected Repository<UserProfile> userProfileRepository;
        protected Repository<UserImage> userImagesRepository;

        public ShareYourselfUow(DbContext context) : base(context) { }

        public Repository<UserProfile> UserProfileRepository => userProfileRepository ?? (userProfileRepository = new Repository<UserProfile>(_context));

        public Repository<UserImage> UserImagesRepository => userImagesRepository ?? (userImagesRepository = new Repository<UserImage>(_context));
    }
}
