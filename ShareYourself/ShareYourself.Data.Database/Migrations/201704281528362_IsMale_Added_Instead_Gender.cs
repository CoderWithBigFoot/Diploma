namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsMale_Added_Instead_Gender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "IsMale", c => c.Boolean());
            DropColumn("dbo.UserProfiles", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "Gender", c => c.Int());
            DropColumn("dbo.UserProfiles", "IsMale");
        }
    }
}
