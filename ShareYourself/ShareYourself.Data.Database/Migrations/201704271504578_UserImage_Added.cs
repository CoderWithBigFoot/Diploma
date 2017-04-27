namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserImage_Added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MimeType = c.String(),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.Id)
                .Index(t => t.Id);         
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserImages", "Id", "dbo.UserProfiles");
            DropIndex("dbo.UserImages", new[] { "Id" });
            DropTable("dbo.UserImages");
        }
    }
}
