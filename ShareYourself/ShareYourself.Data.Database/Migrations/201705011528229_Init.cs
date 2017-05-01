namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        IsMale = c.Boolean(),
                        Status = c.String(),
                        Avatar_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserImages", t => t.Avatar_Id)
                .Index(t => t.Avatar_Id);
            
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MimeType = c.String(),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Name = c.String(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagsPosts", "Tag", "dbo.Tags");
            DropForeignKey("dbo.TagsPosts", "Post", "dbo.UserPosts");
            DropForeignKey("dbo.UserPosts", "CreatorId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "Avatar_Id", "dbo.UserImages");
            DropIndex("dbo.TagsPosts", new[] { "Tag" });
            DropIndex("dbo.TagsPosts", new[] { "Post" });
            DropIndex("dbo.UserPosts", new[] { "CreatorId" });
            DropIndex("dbo.UserProfiles", new[] { "Avatar_Id" });
            DropTable("dbo.TagsPosts");
            DropTable("dbo.Tags");
            DropTable("dbo.UserPosts");
            DropTable("dbo.UserImages");
            DropTable("dbo.UserProfiles");
        }
    }
}
