namespace ChatMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Messages", name: "UserId", newName: "RecipientrUserId");
            RenameIndex(table: "dbo.Messages", name: "IX_UserId", newName: "IX_RecipientrUserId");
            AddColumn("dbo.Messages", "SenderUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Messages", "SenderUserId");
            AddForeignKey("dbo.Messages", "SenderUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "SenderUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "SenderUserId" });
            DropColumn("dbo.Messages", "SenderUserId");
            RenameIndex(table: "dbo.Messages", name: "IX_RecipientrUserId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Messages", name: "RecipientrUserId", newName: "UserId");
        }
    }
}
