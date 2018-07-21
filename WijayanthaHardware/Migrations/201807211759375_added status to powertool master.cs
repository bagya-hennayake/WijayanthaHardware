namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstatustopowertoolmaster : DbMigration
    {
        public override void Up()
        {
            AddColumn("Inventory.PowerToolMaster", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Inventory.PowerToolMaster", "Status");
        }
    }
}
