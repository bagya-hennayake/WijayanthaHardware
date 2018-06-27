namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PowerToolMasterforce : DbMigration
    {
        public override void Up()
        {
            AddColumn("Inventory.PowerToolMaster", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Inventory.PowerToolMaster", "Quantity");
        }
    }
}
