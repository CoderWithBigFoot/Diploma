namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FolSub_Tags_UserPosts_TagsPosts_AreCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreationDate = c.DateTime(),
                        CreatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.CreatorId, cascadeDelete: true)
                .Index(t => t.CreatorId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagsPosts",
                c => new
                    {
                        Post = c.Int(nullable: false),
                        Tag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post, t.Tag })
                .ForeignKey("dbo.UserPosts", t => t.Post, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag, cascadeDelete: true)
                .Index(t => t.Post)
                .Index(t => t.Tag);
            
            CreateTable(
                "dbo.FollowersSubscribers",
                c => new
                    {
                        Subscribing_From = c.Int(nullable: false),
                        Subscribing_To = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subscribing_From, t.Subscribing_To })
                .ForeignKey("dbo.UserProfiles", t => t.Subscribing_From)
                .ForeignKey("dbo.UserProfiles", t => t.Subscribing_To)
                .Index(t => t.Subscribing_From)
                .Index(t => t.Subscribing_To);           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FollowersSubscribers", "Subscribing_To", "dbo.UserProfiles");
            DropForeignKey("dbo.FollowersSubscribers", "Subscribing_From", "dbo.UserProfiles");
            DropForeignKey("dbo.TagsPosts", "Tag", "dbo.Tags");
            DropForeignKey("dbo.TagsPosts", "Post", "dbo.UserPosts");
            DropForeignKey("dbo.UserPosts", "CreatorId", "dbo.UserProfiles");
            DropIndex("dbo.FollowersSubscribers", new[] { "Subscribing_To" });
            DropIndex("dbo.FollowersSubscribers", new[] { "Subscribing_From" });
            DropIndex("dbo.TagsPosts", new[] { "Tag" });
            DropIndex("dbo.TagsPosts", new[] { "Post" });
            DropIndex("dbo.UserPosts", new[] { "CreatorId" });
            DropTable("dbo.FollowersSubscribers");
            DropTable("dbo.TagsPosts");
            DropTable("dbo.Tags");
            DropTable("dbo.UserPosts");
        }
    }
}
