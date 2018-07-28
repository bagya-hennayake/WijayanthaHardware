namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcostcodetopaintmastertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("Inventory.PaintMaster", "CostCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Inventory.PaintMaster", "CostCode");
        }
    }
}
