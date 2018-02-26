namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Davadit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "UserInfo_Id", "dbo.UserInfoes");
            DropForeignKey("dbo.Jobs", "UserInfo_Id", "dbo.UserInfoes");
            DropForeignKey("dbo.Contracts", "UserInfo_Id", "dbo.UserInfoes");
            DropIndex("dbo.Feedbacks", new[] { "UserInfo_Id" });
            DropIndex("dbo.Jobs", new[] { "UserInfo_Id" });
            DropColumn("dbo.Feedbacks", "UserId");
            DropColumn("dbo.Jobs", "UserId");
            RenameColumn(table: "dbo.Contracts", name: "UserInfo_Id", newName: "UserInfo_UserId");
            RenameColumn(table: "dbo.Feedbacks", name: "UserInfo_Id", newName: "UserId");
            RenameColumn(table: "dbo.Jobs", name: "UserInfo_Id", newName: "UserId");
            RenameIndex(table: "dbo.Contracts", name: "IX_UserInfo_Id", newName: "IX_UserInfo_UserId");
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.Feedbacks", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "UserId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.UserInfoes", "UserId");
            CreateIndex("dbo.Feedbacks", "UserId");
            CreateIndex("dbo.Jobs", "UserId");
            AddForeignKey("dbo.Feedbacks", "UserId", "dbo.UserInfoes", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Jobs", "UserId", "dbo.UserInfoes", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Contracts", "UserInfo_UserId", "dbo.UserInfoes", "UserId");
            DropColumn("dbo.UserInfoes", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Contracts", "UserInfo_UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.UserInfoes");
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.UserInfoes");
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.Jobs", "UserId", c => c.Int());
            AlterColumn("dbo.Feedbacks", "UserId", c => c.Int());
            AddPrimaryKey("dbo.UserInfoes", "Id");
            RenameIndex(table: "dbo.Contracts", name: "IX_UserInfo_UserId", newName: "IX_UserInfo_Id");
            RenameColumn(table: "dbo.Jobs", name: "UserId", newName: "UserInfo_Id");
            RenameColumn(table: "dbo.Feedbacks", name: "UserId", newName: "UserInfo_Id");
            RenameColumn(table: "dbo.Contracts", name: "UserInfo_UserId", newName: "UserInfo_Id");
            AddColumn("dbo.Jobs", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Feedbacks", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "UserInfo_Id");
            CreateIndex("dbo.Feedbacks", "UserInfo_Id");
            AddForeignKey("dbo.Contracts", "UserInfo_Id", "dbo.UserInfoes", "Id");
            AddForeignKey("dbo.Jobs", "UserInfo_Id", "dbo.UserInfoes", "Id");
            AddForeignKey("dbo.Feedbacks", "UserInfo_Id", "dbo.UserInfoes", "Id");
        }
    }
}
