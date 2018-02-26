namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProposalsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proposals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Message = c.String(),
                        Job_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .Index(t => t.Job_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proposals", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.Proposals", new[] { "Job_Id" });
            DropTable("dbo.Proposals");
        }
    }
}
