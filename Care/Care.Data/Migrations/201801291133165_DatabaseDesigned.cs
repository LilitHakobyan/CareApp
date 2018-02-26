namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseDesigned : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Addresses", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Users", "AddressID", "dbo.Addresses");
            DropForeignKey("dbo.Users", "AdressID", "dbo.Adresses");
            DropIndex("dbo.Users", new[] { "AddressID" });
            DropIndex("dbo.Addresses", new[] { "CityID" });
            DropIndex("dbo.Cities", new[] { "CountryID" });
            DropColumn("dbo.Users", "AddressID");
            CreateTable(
                "dbo.CareTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        StartedDate = c.DateTime(nullable: false),
                        FinishedDate = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        Canceled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CareTypeId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        Assigned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Roles", "RoleId_Id", c => c.Int());
            AddColumn("dbo.Users", "Login", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "City", c => c.String());
            AddColumn("dbo.Users", "Country", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Role", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "CareTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Photo", c => c.Binary());
            AddColumn("dbo.Users", "AboutMe", c => c.String());
            AddColumn("dbo.Users", "Rating", c => c.Double(nullable: false));
            CreateIndex("dbo.Roles", "RoleId_Id");
            AddForeignKey("dbo.Roles", "RoleId_Id", "dbo.RoleTypes", "Id");
            DropColumn("dbo.Roles", "Type");
            DropTable("dbo.Addresses");
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
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CityID = c.Int(),
                        CountryID = c.Int(),
                        ZIP = c.String(),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "AddressID", c => c.Int());
            AddColumn("dbo.Roles", "Type", c => c.Int(nullable: false));
            DropForeignKey("dbo.Roles", "RoleId_Id", "dbo.RoleTypes");
            DropIndex("dbo.Roles", new[] { "RoleId_Id" });
            DropColumn("dbo.Users", "Rating");
            DropColumn("dbo.Users", "AboutMe");
            DropColumn("dbo.Users", "Photo");
            DropColumn("dbo.Users", "CareTypeId");
            DropColumn("dbo.Users", "Role");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "Country");
            DropColumn("dbo.Users", "City");
            DropColumn("dbo.Users", "Address");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Login");
            DropColumn("dbo.Roles", "RoleId_Id");
            DropTable("dbo.RoleTypes");
            DropTable("dbo.Jobs");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Contracts");
            DropTable("dbo.CareTypes");
            CreateIndex("dbo.Users", "AddressID");
            CreateIndex("dbo.Cities", "CountryID");
            CreateIndex("dbo.Addresses", "CityID");
            AddForeignKey("dbo.Users", "AddressID", "dbo.Addresses", "ID");
            AddForeignKey("dbo.Addresses", "CityID", "dbo.Cities", "ID");
            AddForeignKey("dbo.Cities", "CountryID", "dbo.Countries", "ID", cascadeDelete: true);
        }
    }
}
