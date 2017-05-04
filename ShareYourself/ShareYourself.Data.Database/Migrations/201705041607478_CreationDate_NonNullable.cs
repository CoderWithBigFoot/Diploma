namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreationDate_NonNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserPosts", "CreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserPosts", "CreationDate", c => c.DateTime());
        }
    }
}
