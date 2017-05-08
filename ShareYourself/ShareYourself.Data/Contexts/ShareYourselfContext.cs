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
                .HasOptional(x => x.Avatar)
                .WithMany(x => x.Owners);

            modelBuilder.Entity<UserImage>()
               .HasKey(x => x.Id);

             modelBuilder.Entity<UserProfile>()
                 .HasMany(x => x.Followers)
                 .WithMany(x => x.Subscriptions)
                 .Map(x =>
                 {
                     x.MapLeftKey("ToId");
                     x.MapRightKey("FromId");
                     x.ToTable("Subscriptions");
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
                     x.MapLeftKey("PostId");
                     x.MapRightKey("TagId");
                     x.ToTable("TagsPosts");
                 });

            modelBuilder.Entity<UserPost>()
                .HasMany(x => x.Likes)
                .WithMany(x => x.Likes)
                .Map(x => 
                {
                    x.MapLeftKey("PostId");
                    x.MapRightKey("LikerId");
                    x.ToTable("Likes");
                });

            modelBuilder.Entity<Tag>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Tag>()
                .Property(x => x.Name)
                .IsRequired();
        }
    }
}
