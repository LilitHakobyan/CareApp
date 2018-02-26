namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "CareType", c => c.Int(nullable: false));
            DropColumn("dbo.Jobs", "CareTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "CareTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Jobs", "CareType");
        }
    }
}
