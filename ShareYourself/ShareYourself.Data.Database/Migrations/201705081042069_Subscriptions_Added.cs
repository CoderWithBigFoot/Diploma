namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subscriptions_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subscriptions",
                c => new
                    {
                        ToId = c.Int(nullable: false),
                        FromId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ToId, t.FromId })
                .ForeignKey("dbo.UserProfiles", t => t.ToId)
                .ForeignKey("dbo.UserProfiles", t => t.FromId)
                .Index(t => t.ToId)
                .Index(t => t.FromId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscriptions", "FromId", "dbo.UserProfiles");
            DropForeignKey("dbo.Subscriptions", "ToId", "dbo.UserProfiles");
            DropIndex("dbo.Subscriptions", new[] { "FromId" });
            DropIndex("dbo.Subscriptions", new[] { "ToId" });
            DropTable("dbo.Subscriptions");
        }
    }
}
