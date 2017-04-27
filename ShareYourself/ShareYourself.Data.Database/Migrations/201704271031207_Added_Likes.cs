namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Likes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        LikedUserPost = c.Int(nullable: false),
                        LikedUserProfile = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LikedUserPost, t.LikedUserProfile })
                .ForeignKey("dbo.UserPosts", t => t.LikedUserPost, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.LikedUserProfile, cascadeDelete: false)
                .Index(t => t.LikedUserPost)
                .Index(t => t.LikedUserProfile);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "LikedUserProfile", "dbo.UserProfiles");
            DropForeignKey("dbo.Likes", "LikedUserPost", "dbo.UserPosts");
            DropIndex("dbo.Likes", new[] { "LikedUserProfile" });
            DropIndex("dbo.Likes", new[] { "LikedUserPost" });
            DropTable("dbo.Likes");
        }
    }
}
