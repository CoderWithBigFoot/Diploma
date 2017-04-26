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

            modelBuilder.Entity<UserProfile>()
                .HasMany(x => x.Subscriptions)
                .WithMany(x => x.Followers)
                .Map(x =>
                {
                    x.MapLeftKey("Subscribing_From");
                    x.MapRightKey("Subscribing_To");
                    x.ToTable("FollowersSubscribers");
                });

            modelBuilder.Entity<UserPost>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<UserPost>()
                .HasRequired(x => x.Creator)
                .WithMany(x => x.Publications);

            modelBuilder.Entity<UserPost>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .Map(x =>
                {
                    x.MapLeftKey("Tag");
                    x.MapRightKey("Post");
                    x.ToTable("TagsPosts");
                });

            modelBuilder.Entity<UserPost>()
                .HasMany(x => x.Likes)
                .WithMany(x => x.Likes)
                .Map(x => 
                {
                    x.MapLeftKey("LikedUserProfile");
                    x.MapRightKey("LikedUserPost");
                    x.ToTable("Likes");
                });

            modelBuilder.Entity<UserPost>()
                .HasMany(x => x.Reposts)
                .WithMany(x => x.Reposts)
                .Map(x => 
                {
                    x.MapLeftKey("Reposter");
                    x.MapRightKey("RepostedUserPost");
                    x.ToTable("Reposts");
                });

            modelBuilder.Entity<Tag>()
                .HasKey(x => x.Id);


        }

    }
}
