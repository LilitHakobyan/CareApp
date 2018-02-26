namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobHasFeedbacks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.UserInfoes");
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            AddColumn("dbo.Feedbacks", "Job_Id", c => c.Int());
            CreateIndex("dbo.Feedbacks", "Job_Id");
            AddForeignKey("dbo.Feedbacks", "Job_Id", "dbo.Jobs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.Feedbacks", new[] { "Job_Id" });
            DropColumn("dbo.Feedbacks", "Job_Id");
            CreateIndex("dbo.Feedbacks", "UserId");
            AddForeignKey("dbo.Feedbacks", "UserId", "dbo.UserInfoes", "UserId", cascadeDelete: true);
        }
    }
}
