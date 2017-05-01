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

            /* modelBuilder.Entity<UserProfile>()
                 .HasMany(x => x.Followers)
                 .WithMany(x => x.Subscriptions)
                 .Map(x =>
                 {
                     x.MapLeftKey("Subscribing_To");
                     x.MapRightKey("Subscribing_From");
                     x.ToTable("FollowersSubscribers");
                 });*/

            modelBuilder.Entity<UserProfile>()
                .HasOptional(x => x.Avatar)
                .WithOptionalDependent(x => x.Creator);
                

 
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
                    x.MapLeftKey("Post");
                    x.MapRightKey("Tag");
                    x.ToTable("TagsPosts");
                });

           /* modelBuilder.Entity<UserPost>()
                .HasMany(x => x.Likes)
                .WithMany(x => x.Likes)
                .Map(x => 
                {
                    x.MapLeftKey("LikedUserPost");
                    x.MapRightKey("LikedUserProfile"); 
                    x.ToTable("Likes");
                });

            modelBuilder.Entity<UserPost>()
                .HasMany(x => x.Reposts)
                .WithMany(x => x.Reposts)
                .Map(x => 
                {
                    x.MapLeftKey("RepostedUserPost");
                    x.MapRightKey("Reposter");
                    x.ToTable("Reposts");
                });              
                */


            modelBuilder.Entity<Tag>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Tag>()
                .Property(x => x.Name)
                .IsRequired();



            modelBuilder.Entity<UserImage>()
                .HasKey(x => x.Id);
        }

    }
}
