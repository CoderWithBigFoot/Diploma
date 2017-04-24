using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GenericRepository.Data.EntityFramework;
using ShareYourself.Data.Entities;

namespace ShareYourself.Data
{
    public class ShareYourselfUow : UnitOfWork
    {
        protected Repository<UserProfile> userProfileRepository;

        public ShareYourselfUow(DbContext context) : base(context) { }

        public Repository<UserProfile> UserProfileRepository => userProfileRepository ?? new Repository<UserProfile>(_context);
    }
}
