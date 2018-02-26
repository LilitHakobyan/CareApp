namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.Contracts", "UserInfo_UserId", "dbo.UserInfoes");
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropIndex("dbo.Jobs", new[] { "UserId" });
            RenameColumn(table: "dbo.Contracts", name: "UserInfo_UserId", newName: "UserInfo_ID");
            RenameIndex(table: "dbo.Contracts", name: "IX_UserInfo_UserId", newName: "IX_UserInfo_ID");
            DropPrimaryKey("dbo.UserInfoes");
            AddColumn("dbo.Feedbacks", "UserInfo_ID", c => c.Int());
            AddColumn("dbo.Jobs", "UserInfo_ID", c => c.Int());
            AddColumn("dbo.UserInfoes", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserInfoes", "ID");
            CreateIndex("dbo.Feedbacks", "UserInfo_ID");
            CreateIndex("dbo.Jobs", "UserInfo_ID");
            AddForeignKey("dbo.Feedbacks", "UserInfo_ID", "dbo.UserInfoes", "ID");
            AddForeignKey("dbo.Jobs", "UserInfo_ID", "dbo.UserInfoes", "ID");
            AddForeignKey("dbo.Contracts", "UserInfo_ID", "dbo.UserInfoes", "ID");
            DropColumn("dbo.UserInfoes", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contracts", "UserInfo_ID", "dbo.UserInfoes");
            DropForeignKey("dbo.Jobs", "UserInfo_ID", "dbo.UserInfoes");
            DropForeignKey("dbo.Feedbacks", "UserInfo_ID", "dbo.UserInfoes");
            DropIndex("dbo.Jobs", new[] { "UserInfo_ID" });
            DropIndex("dbo.Feedbacks", new[] { "UserInfo_ID" });
            DropPrimaryKey("dbo.UserInfoes");
            DropColumn("dbo.UserInfoes", "ID");
            DropColumn("dbo.Jobs", "UserInfo_ID");
            DropColumn("dbo.Feedbacks", "UserInfo_ID");
            AddPrimaryKey("dbo.UserInfoes", "UserId");
            RenameIndex(table: "dbo.Contracts", name: "IX_UserInfo_ID", newName: "IX_UserInfo_UserId");
            RenameColumn(table: "dbo.Contracts", name: "UserInfo_ID", newName: "UserInfo_UserId");
            CreateIndex("dbo.Jobs", "UserId");
            CreateIndex("dbo.Feedbacks", "UserId");
            AddForeignKey("dbo.Contracts", "UserInfo_UserId", "dbo.UserInfoes", "UserId");
            AddForeignKey("dbo.Jobs", "UserId", "dbo.UserInfoes", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "UserId", "dbo.UserInfoes", "UserId", cascadeDelete: true);
        }
    }
}
