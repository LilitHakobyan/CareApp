namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBFinal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfos",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CareTypeId = c.Int(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        Photo = c.Binary(),
                        AboutMe = c.String(),
                        Rating = c.Double(nullable: false),
                        Age = c.Int(),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Contracts", "UserInfo_UserId", c => c.Int());
            CreateIndex("dbo.Contracts", "UserInfo_UserId");
            CreateIndex("dbo.Feedbacks", "UserId");
            CreateIndex("dbo.Jobs", "UserId");
            AddForeignKey("dbo.Contracts", "UserInfo_UserId", "dbo.UserInfos", "UserId");
            AddForeignKey("dbo.Feedbacks", "UserId", "dbo.UserInfos", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Jobs", "UserId", "dbo.UserInfos", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "UserId", "dbo.UserInfos");
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.UserInfos");
            DropForeignKey("dbo.Contracts", "UserInfo_UserId", "dbo.UserInfos");
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropIndex("dbo.Contracts", new[] { "UserInfo_UserId" });
            DropColumn("dbo.Contracts", "UserInfo_UserId");
            DropTable("dbo.UserInfos");
        }
    }
}
