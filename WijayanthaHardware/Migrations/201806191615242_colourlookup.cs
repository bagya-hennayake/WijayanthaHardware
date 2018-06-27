namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colourlookup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "LookUp.PaintColour",
                c => new
                    {
                        PaintColourId = c.Int(nullable: false, identity: true),
                        PaintCategoryId = c.Int(nullable: false),
                        PaintProductId = c.Int(nullable: false),
                        Colour = c.String(),
                        ColourCode = c.String(),
                    })
                .PrimaryKey(t => t.PaintColourId)
                .ForeignKey("LookUp.PaintCategory", t => t.PaintCategoryId, cascadeDelete: true)
                .ForeignKey("LookUp.PaintProduct", t => t.PaintProductId, cascadeDelete: true)
                .Index(t => t.PaintCategoryId)
                .Index(t => t.PaintProductId);
            
            CreateTable(
                "LookUp.PaintProduct",
                c => new
                    {
                        PaintProductId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PaintProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("LookUp.PaintColour", "PaintProductId", "LookUp.PaintProduct");
            DropForeignKey("LookUp.PaintColour", "PaintCategoryId", "LookUp.PaintCategory");
            DropIndex("LookUp.PaintColour", new[] { "PaintProductId" });
            DropIndex("LookUp.PaintColour", new[] { "PaintCategoryId" });
            DropTable("LookUp.PaintProduct");
            DropTable("LookUp.PaintColour");
        }
    }
}
