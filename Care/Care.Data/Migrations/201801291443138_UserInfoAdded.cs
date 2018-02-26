namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInfoAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.City_ID)
                .Index(t => t.City_ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.Country_ID)
                .Index(t => t.Country_ID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "Address_ID", c => c.Int());
            CreateIndex("dbo.Users", "Address_ID");
            AddForeignKey("dbo.Users", "Address_ID", "dbo.Adresses", "ID");
            DropColumn("dbo.Users", "Login");
            DropColumn("dbo.Users", "Gender");
            DropColumn("dbo.Users", "Address");
            DropColumn("dbo.Users", "City");
            DropColumn("dbo.Users", "Country");
            DropColumn("dbo.Users", "CareTypeId");
            DropColumn("dbo.Users", "Photo");
            DropColumn("dbo.Users", "AboutMe");
            DropColumn("dbo.Users", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Rating", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "AboutMe", c => c.String());
            AddColumn("dbo.Users", "Photo", c => c.Binary());
            AddColumn("dbo.Users", "CareTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Country", c => c.String());
            AddColumn("dbo.Users", "City", c => c.String());
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "Gender", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Login", c => c.String());
            DropForeignKey("dbo.Users", "Address_ID", "dbo.Adresses");
            DropForeignKey("dbo.Adresses", "City_ID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "Country_ID", "dbo.Countries");
            DropIndex("dbo.Cities", new[] { "Country_ID" });
            DropIndex("dbo.Adresses", new[] { "City_ID" });
            DropIndex("dbo.Users", new[] { "Address_ID" });
            DropColumn("dbo.Users", "Address_ID");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Adresses");
        }
    }
}
