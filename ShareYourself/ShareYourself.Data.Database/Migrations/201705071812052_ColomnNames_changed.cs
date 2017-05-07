namespace ShareYourself.Data.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColomnNames_changed : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Likes", name: "Post", newName: "PostId");
            RenameColumn(table: "dbo.Likes", name: "Liker", newName: "LikerId");
            RenameColumn(table: "dbo.TagsPosts", name: "Post", newName: "PostId");
            RenameColumn(table: "dbo.TagsPosts", name: "Tag", newName: "TagId");
            RenameIndex(table: "dbo.Likes", name: "IX_Post", newName: "IX_PostId");
            RenameIndex(table: "dbo.Likes", name: "IX_Liker", newName: "IX_LikerId");
            RenameIndex(table: "dbo.TagsPosts", name: "IX_Post", newName: "IX_PostId");
            RenameIndex(table: "dbo.TagsPosts", name: "IX_Tag", newName: "IX_TagId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TagsPosts", name: "IX_TagId", newName: "IX_Tag");
            RenameIndex(table: "dbo.TagsPosts", name: "IX_PostId", newName: "IX_Post");
            RenameIndex(table: "dbo.Likes", name: "IX_LikerId", newName: "IX_Liker");
            RenameIndex(table: "dbo.Likes", name: "IX_PostId", newName: "IX_Post");
            RenameColumn(table: "dbo.TagsPosts", name: "TagId", newName: "Tag");
            RenameColumn(table: "dbo.TagsPosts", name: "PostId", newName: "Post");
            RenameColumn(table: "dbo.Likes", name: "LikerId", newName: "Liker");
            RenameColumn(table: "dbo.Likes", name: "PostId", newName: "Post");
        }
    }
}
