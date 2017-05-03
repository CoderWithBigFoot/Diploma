namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfiles_UserImages_Added : DbMigration
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
                        RegistrationDate = c.DateTime(nullable: false),
                        AvatarId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserImages", t => t.AvatarId)
                .Index(t => t.AvatarId);
            
            CreateTable(
                "dbo.UserImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MimeType = c.String(),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "AvatarId", "dbo.UserImages");
            DropIndex("dbo.UserProfiles", new[] { "AvatarId" });
            DropTable("dbo.UserImages");
            DropTable("dbo.UserProfiles");
        }
    }
}
