namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "LookUp.PaintCategory",
                c => new
                    {
                        PaintCategoryId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PaintCategoryId);
            
            CreateTable(
                "LookUp.PaintColour",
                c => new
                    {
                        PaintColourId = c.Int(nullable: false, identity: true),
                        Colour = c.String(),
                        ColourCode = c.String(),
                    })
                .PrimaryKey(t => t.PaintColourId);
            
            CreateTable(
                "Inventory.PaintMaster",
                c => new
                    {
                        PaintMasterId = c.Int(nullable: false, identity: true),
                        PaintColourId = c.Int(nullable: false),
                        PaintCategoryId = c.Int(nullable: false),
                        VolumeId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        PaintSubCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaintMasterId)
                .ForeignKey("LookUp.PaintCategory", t => t.PaintCategoryId, cascadeDelete: true)
                .ForeignKey("LookUp.PaintColour", t => t.PaintColourId, cascadeDelete: true)
                .ForeignKey("LookUp.PaintSubCategory", t => t.PaintSubCategoryId, cascadeDelete: true)
                .ForeignKey("LookUp.PaintVolume", t => t.VolumeId, cascadeDelete: true)
                .Index(t => t.PaintColourId)
                .Index(t => t.PaintCategoryId)
                .Index(t => t.VolumeId)
                .Index(t => t.PaintSubCategoryId);
            
            CreateTable(
                "LookUp.PaintSubCategory",
                c => new
                    {
                        PaintSubCategoryId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PaintSubCategoryId);
            
            CreateTable(
                "LookUp.PaintVolume",
                c => new
                    {
                        VolumeId = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.VolumeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Inventory.PaintMaster", "VolumeId", "LookUp.PaintVolume");
            DropForeignKey("Inventory.PaintMaster", "PaintSubCategoryId", "LookUp.PaintSubCategory");
            DropForeignKey("Inventory.PaintMaster", "PaintColourId", "LookUp.PaintColour");
            DropForeignKey("Inventory.PaintMaster", "PaintCategoryId", "LookUp.PaintCategory");
            DropIndex("Inventory.PaintMaster", new[] { "PaintSubCategoryId" });
            DropIndex("Inventory.PaintMaster", new[] { "VolumeId" });
            DropIndex("Inventory.PaintMaster", new[] { "PaintCategoryId" });
            DropIndex("Inventory.PaintMaster", new[] { "PaintColourId" });
            DropTable("LookUp.PaintVolume");
            DropTable("LookUp.PaintSubCategory");
            DropTable("Inventory.PaintMaster");
            DropTable("LookUp.PaintColour");
            DropTable("LookUp.PaintCategory");
        }
    }
}
