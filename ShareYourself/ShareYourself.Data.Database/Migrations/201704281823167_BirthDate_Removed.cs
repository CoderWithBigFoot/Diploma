namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthDate_Removed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfiles", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "BirthDate", c => c.DateTime());
        }
    }
}
