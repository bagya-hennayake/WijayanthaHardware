namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PowertoolTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "LookUp.PowerToolCategory",
                c => new
                    {
                        PowerToolCategoryId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PowerToolCategoryId);
            
            CreateTable(
                "LookUp.PowerToolSubCatogery",
                c => new
                    {
                        PowerToolSubCatogeryId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PowerToolSubCatogeryId);
            
            AddColumn("LookUp.PaintCategory", "Status", c => c.Int(nullable: false));
            AddColumn("LookUp.PaintColour", "Status", c => c.Int(nullable: false));
            AddColumn("Inventory.PaintMaster", "Status", c => c.Int(nullable: false));
            AddColumn("LookUp.PaintSubCategory", "Status", c => c.Int(nullable: false));
            AddColumn("LookUp.PaintVolume", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("LookUp.PaintVolume", "Status");
            DropColumn("LookUp.PaintSubCategory", "Status");
            DropColumn("Inventory.PaintMaster", "Status");
            DropColumn("LookUp.PaintColour", "Status");
            DropColumn("LookUp.PaintCategory", "Status");
            DropTable("LookUp.PowerToolSubCatogery");
            DropTable("LookUp.PowerToolCategory");
        }
    }
}
