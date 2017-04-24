using System.Data.Entity;
using ShareYourself.Data.Entities;

namespace ShareYourself.Data.Contexts
{
    public class ShareYourselfContext : DbContext
    {
        public ShareYourselfContext(string connectionString) : base(connectionString){ }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasKey(x => x.Id);
        }

    }
}
