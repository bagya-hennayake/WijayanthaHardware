namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaintCategoryforce : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("LookUp.PaintColour", "PaintProductId", "LookUp.PaintProduct");
            DropIndex("LookUp.PaintColour", new[] { "PaintProductId" });
            RenameColumn(table: "LookUp.PaintColour", name: "PaintCategory_PaintDefLevel", newName: "PaintCategoryDef_PaintDefLevel");
            RenameIndex(table: "LookUp.PaintColour", name: "IX_PaintCategory_PaintDefLevel", newName: "IX_PaintCategoryDef_PaintDefLevel");
            AddColumn("LookUp.PaintColour", "PCategory_1", c => c.Int(nullable: false));
            AddColumn("LookUp.PaintColour", "PCategory_2", c => c.Int(nullable: false));
            AddColumn("LookUp.PaintColour", "PCategory_3", c => c.Int(nullable: false));
            AddColumn("LookUp.PaintColour", "PCategory_4", c => c.Int(nullable: false));
            AddColumn("LookUp.PaintColour", "PCategory_5", c => c.Int(nullable: false));
            DropColumn("LookUp.PaintColour", "PaintCategoryId");
            DropColumn("LookUp.PaintColour", "PaintProductId");
            DropTable("LookUp.PaintProduct");
        }
        
        public override void Down()
        {
            CreateTable(
                "LookUp.PaintProduct",
                c => new
                    {
                        PaintProductId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PaintProductId);
            
            AddColumn("LookUp.PaintColour", "PaintProductId", c => c.Int(nullable: false));
            AddColumn("LookUp.PaintColour", "PaintCategoryId", c => c.Int(nullable: false));
            DropColumn("LookUp.PaintColour", "PCategory_5");
            DropColumn("LookUp.PaintColour", "PCategory_4");
            DropColumn("LookUp.PaintColour", "PCategory_3");
            DropColumn("LookUp.PaintColour", "PCategory_2");
            DropColumn("LookUp.PaintColour", "PCategory_1");
            RenameIndex(table: "LookUp.PaintColour", name: "IX_PaintCategoryDef_PaintDefLevel", newName: "IX_PaintCategory_PaintDefLevel");
            RenameColumn(table: "LookUp.PaintColour", name: "PaintCategoryDef_PaintDefLevel", newName: "PaintCategory_PaintDefLevel");
            CreateIndex("LookUp.PaintColour", "PaintProductId");
            AddForeignKey("LookUp.PaintColour", "PaintProductId", "LookUp.PaintProduct", "PaintProductId", cascadeDelete: true);
        }
    }
}
