using System.Data.Entity;
using GenericRepository.Data.EntityFramework;
using ShareYourself.Data.Entities;

namespace ShareYourself.Data
{
    public class ShareYourselfUow : UnitOfWork, IShareYourselfUow
    {
        protected Repository<UserProfile> userProfileRepository;

        public ShareYourselfUow(DbContext context) : base(context) { }

        public Repository<UserProfile> UserProfileRepository => userProfileRepository ?? new Repository<UserProfile>(_context);
    }
}
