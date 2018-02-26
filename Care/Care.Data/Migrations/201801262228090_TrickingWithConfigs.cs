namespace Care.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrickingWithConfigs : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Adresses", newName: "Addresses");
            RenameColumn(table: "dbo.Users", name: "AdressID", newName: "AddressID");
            RenameIndex(table: "dbo.Users", name: "IX_AdressID", newName: "IX_AddressID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_AddressID", newName: "IX_AdressID");
            RenameColumn(table: "dbo.Users", name: "AddressID", newName: "AdressID");
            RenameTable(name: "dbo.Addresses", newName: "Adresses");
        }
    }
}
