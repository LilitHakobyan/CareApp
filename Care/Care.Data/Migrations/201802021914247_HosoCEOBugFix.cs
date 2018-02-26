namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HosoCEOBugFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.Contracts", "UserInfo_UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.Contracts", "UserInfo_UserId", "dbo.UserInfos");
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.UserInfos");
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropIndex("dbo.Jobs", new[] { "UserId" });
            RenameColumn(table: "dbo.Contracts", name: "UserInfo_UserId", newName: "UserInfo_Id");
            RenameIndex(table: "dbo.Contracts", name: "IX_UserInfo_UserId", newName: "IX_UserInfo_Id");
            DropPrimaryKey("dbo.UserInfoes");
            AddColumn("dbo.Feedbacks", "UserInfo_Id", c => c.Int());
            AddColumn("dbo.Jobs", "UserInfo_Id", c => c.Int());
            AddColumn("dbo.UserInfoes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserInfoes", "Id");
            CreateIndex("dbo.Feedbacks", "UserInfo_Id");
            CreateIndex("dbo.Jobs", "UserInfo_Id");
            AddForeignKey("dbo.Feedbacks", "UserInfo_Id", "dbo.UserInfoes", "Id");
            AddForeignKey("dbo.Jobs", "UserInfo_Id", "dbo.UserInfoes", "Id");
            AddForeignKey("dbo.Contracts", "UserInfo_Id", "dbo.UserInfoes", "Id");
        }
        
        public override void Down()
        {

            DropForeignKey("dbo.Contracts", "UserInfo_Id", "dbo.UserInfoes");
            DropForeignKey("dbo.Jobs", "UserInfo_Id", "dbo.UserInfoes");
            DropForeignKey("dbo.Feedbacks", "UserInfo_Id", "dbo.UserInfoes");
            DropIndex("dbo.Jobs", new[] { "UserInfo_Id" });
            DropIndex("dbo.Feedbacks", new[] { "UserInfo_Id" });
            DropPrimaryKey("dbo.UserInfoes");
            DropColumn("dbo.UserInfoes", "Id");
            DropColumn("dbo.Jobs", "UserInfo_Id");
            DropColumn("dbo.Feedbacks", "UserInfo_Id");
            AddPrimaryKey("dbo.UserInfoes", "UserId");
            RenameIndex(table: "dbo.Contracts", name: "IX_UserInfo_Id", newName: "IX_UserInfo_UserId");
            RenameColumn(table: "dbo.Contracts", name: "UserInfo_Id", newName: "UserInfo_UserId");
            CreateIndex("dbo.Jobs", "UserId");
            CreateIndex("dbo.Feedbacks", "UserId");
            AddForeignKey("dbo.Contracts", "UserInfo_UserId", "dbo.UserInfoes", "UserId");
            AddForeignKey("dbo.Jobs", "UserId", "dbo.UserInfoes", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "UserId", "dbo.UserInfoes", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Contracts", "UserInfo_UserId", "dbo.UserInfos", "UserInfo_UserId", cascadeDelete: true);
            AddForeignKey("dbo.Feedbacks", "UserId", "dbo.UserInfos", "UserId", cascadeDelete: true);
        }
    }
}
