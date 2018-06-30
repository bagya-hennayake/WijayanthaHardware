namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PowerToolMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Inventory.PowerToolMaster",
                c => new
                    {
                        PowerToolMasterId = c.Int(nullable: false, identity: true),
                        PowerToolCategoryId = c.Int(nullable: false),
                        PowerToolSubCatogeryId = c.Int(nullable: false),
                        Detail = c.String(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PowerToolMasterId)
                .ForeignKey("LookUp.PowerToolCategory", t => t.PowerToolCategoryId, cascadeDelete: true)
                .ForeignKey("LookUp.PowerToolSubCatogery", t => t.PowerToolSubCatogeryId, cascadeDelete: true)
                .Index(t => t.PowerToolCategoryId)
                .Index(t => t.PowerToolSubCatogeryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Inventory.PowerToolMaster", "PowerToolSubCatogeryId", "LookUp.PowerToolSubCatogery");
            DropForeignKey("Inventory.PowerToolMaster", "PowerToolCategoryId", "LookUp.PowerToolCategory");
            DropIndex("Inventory.PowerToolMaster", new[] { "PowerToolSubCatogeryId" });
            DropIndex("Inventory.PowerToolMaster", new[] { "PowerToolCategoryId" });
            DropTable("Inventory.PowerToolMaster");
        }
    }
}
