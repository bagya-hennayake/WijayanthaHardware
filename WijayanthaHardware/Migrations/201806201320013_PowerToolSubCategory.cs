namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PowerToolSubCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("Inventory.PaintMaster", "VolumeId", c => c.Int(nullable: false));
            CreateIndex("Inventory.PaintMaster", "VolumeId");
            AddForeignKey("Inventory.PaintMaster", "VolumeId", "LookUp.PaintVolume", "VolumeId", cascadeDelete: true);
            DropColumn("LookUp.PowerToolsCategory", "Value");
            DropColumn("LookUp.PowerToolsCategory", "Details");
        }
        
        public override void Down()
        {
            AddColumn("LookUp.PowerToolsCategory", "Details", c => c.Int(nullable: false));
            AddColumn("LookUp.PowerToolsCategory", "Value", c => c.String());
            DropForeignKey("Inventory.PaintMaster", "VolumeId", "LookUp.PaintVolume");
            DropIndex("Inventory.PaintMaster", new[] { "VolumeId" });
            DropColumn("Inventory.PaintMaster", "VolumeId");
        }
    }
}
