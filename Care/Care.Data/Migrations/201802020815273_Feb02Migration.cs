namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feb02Migration : DbMigration
    {
        public override void Up()
        {
            RenameTable("UserInfos", "UserInfoes");
        }
        
        public override void Down()
        {
        }
    }
}
