using System.Data.Entity;
using GenericRepository.Data.EntityFramework;
using ShareYourself.Data.Entities;

namespace ShareYourself.Data
{
    public class ShareYourselfUow : UnitOfWork, IShareYourselfUow
    {
        protected Repository<UserProfile> userProfilesRepository;
        protected Repository<UserImage> userImagesRepository;
        protected Repository<UserPost> userPostsRepoitory;
        protected Repository<Tag> tagsRepository;

        public ShareYourselfUow(DbContext context) : base(context) { }

        public Repository<UserProfile> UserProfilesRepository => userProfilesRepository ?? (userProfilesRepository = new Repository<UserProfile>(_context));

        public Repository<UserImage> UserImagesRepository => userImagesRepository ?? (userImagesRepository = new Repository<UserImage>(_context));

        public Repository<UserPost> UserPostsRepository => userPostsRepoitory ?? (userPostsRepoitory = new Repository<UserPost>(_context));

        public Repository<Tag> TagsRepository => tagsRepository ?? (tagsRepository = new Repository<Tag>(_context));
    }
}
