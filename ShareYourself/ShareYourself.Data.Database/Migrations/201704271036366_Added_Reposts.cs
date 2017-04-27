namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Reposts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reposts",
                c => new
                    {
                        RepostedUserPost = c.Int(nullable: false),
                        Reposter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RepostedUserPost, t.Reposter })
                .ForeignKey("dbo.UserPosts", t => t.RepostedUserPost, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.Reposter, cascadeDelete: false)
                .Index(t => t.RepostedUserPost)
                .Index(t => t.Reposter);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reposts", "Reposter", "dbo.UserProfiles");
            DropForeignKey("dbo.Reposts", "RepostedUserPost", "dbo.UserPosts");
            DropIndex("dbo.Reposts", new[] { "Reposter" });
            DropIndex("dbo.Reposts", new[] { "RepostedUserPost" });
            DropTable("dbo.Reposts");
        }
    }
}
