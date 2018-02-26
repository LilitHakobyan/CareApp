namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobPropertiesNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jobs", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Jobs", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Jobs", "Price", c => c.Double());
            AlterColumn("dbo.Jobs", "Assigned", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "Assigned", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Jobs", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Jobs", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
