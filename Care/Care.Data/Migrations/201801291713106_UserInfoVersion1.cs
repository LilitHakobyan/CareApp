namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInfoVersion1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "Country_ID", "dbo.Countries");
            DropForeignKey("dbo.Adresses", "City_ID", "dbo.Cities");
            DropForeignKey("dbo.Users", "Address_ID", "dbo.Adresses");
            DropIndex("dbo.Users", new[] { "Address_ID" });
            DropIndex("dbo.Adresses", new[] { "City_ID" });
            DropIndex("dbo.Cities", new[] { "Country_ID" });
            AddColumn("dbo.Users", "RoleTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Age");
            DropColumn("dbo.Users", "Role");
            DropColumn("dbo.Users", "Address_ID");
            DropTable("dbo.Adresses");
            DropTable("dbo.Cities");
            DropTable("dbo.Countries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "Address_ID", c => c.Int());
            AddColumn("dbo.Users", "Role", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Age", c => c.Int());
            DropColumn("dbo.Users", "RoleTypeId");
            CreateIndex("dbo.Cities", "Country_ID");
            CreateIndex("dbo.Adresses", "City_ID");
            CreateIndex("dbo.Users", "Address_ID");
            AddForeignKey("dbo.Users", "Address_ID", "dbo.Adresses", "ID");
            AddForeignKey("dbo.Adresses", "City_ID", "dbo.Cities", "ID");
            AddForeignKey("dbo.Cities", "Country_ID", "dbo.Countries", "ID");
        }
    }
}
