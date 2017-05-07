namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Likes_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Post = c.Int(nullable: false),
                        Liker = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post, t.Liker })
                .ForeignKey("dbo.UserPosts", t => t.Post, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.Liker, cascadeDelete: false)
                .Index(t => t.Post)
                .Index(t => t.Liker);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "Liker", "dbo.UserProfiles");
            DropForeignKey("dbo.Likes", "Post", "dbo.UserPosts");
            DropIndex("dbo.Likes", new[] { "Liker" });
            DropIndex("dbo.Likes", new[] { "Post" });
            DropTable("dbo.Likes");
        }
    }
}
