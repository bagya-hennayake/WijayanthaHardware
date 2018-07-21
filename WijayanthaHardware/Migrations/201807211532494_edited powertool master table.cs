namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedpowertoolmastertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("Inventory.PowerToolMaster", "Price", c => c.Double(nullable: false));
            AddColumn("Inventory.PowerToolMaster", "CostCode", c => c.String());
            AddColumn("Inventory.PowerToolMaster", "WarrantyPeriod", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Inventory.PowerToolMaster", "WarrantyPeriod");
            DropColumn("Inventory.PowerToolMaster", "CostCode");
            DropColumn("Inventory.PowerToolMaster", "Price");
        }
    }
}
