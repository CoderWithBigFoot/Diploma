namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status_Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Status");
        }
    }
}
