namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityID = c.Int(),
                        CountryID = c.Int(),
                        ZIP = c.String(),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Int(),
                        Gender = c.Boolean(nullable: false),
                        AdressID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Adresses", t => t.AdressID)
                .Index(t => t.AdressID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AdressID", "dbo.Adresses");
            DropForeignKey("dbo.Adresses", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryID", "dbo.Countries");
            DropIndex("dbo.Users", new[] { "AdressID" });
            DropIndex("dbo.Cities", new[] { "CountryID" });
            DropIndex("dbo.Adresses", new[] { "CityID" });
            DropTable("dbo.Users");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Adresses");
        }
    }
}
