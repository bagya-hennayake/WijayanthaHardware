namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaintCategoryDef : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("LookUp.PaintColour", "PaintCategoryId", "LookUp.PaintCategory");
            DropIndex("LookUp.PaintColour", new[] { "PaintCategoryId" });
            CreateTable(
                "LookUp.PaintCategoryDef",
                c => new
                    {
                        PaintDefLevel = c.Int(nullable: false, identity: true),
                        PaintDefName = c.String(),
                    })
                .PrimaryKey(t => t.PaintDefLevel);
            
            AddColumn("LookUp.PaintColour", "PaintCategory_PaintDefLevel", c => c.Int());
            CreateIndex("LookUp.PaintColour", "PaintCategory_PaintDefLevel");
            AddForeignKey("LookUp.PaintColour", "PaintCategory_PaintDefLevel", "LookUp.PaintCategoryDef", "PaintDefLevel");
            DropTable("LookUp.PaintCategory");
        }
        
        public override void Down()
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
            
            DropForeignKey("LookUp.PaintColour", "PaintCategory_PaintDefLevel", "LookUp.PaintCategoryDef");
            DropIndex("LookUp.PaintColour", new[] { "PaintCategory_PaintDefLevel" });
            DropColumn("LookUp.PaintColour", "PaintCategory_PaintDefLevel");
            DropTable("LookUp.PaintCategoryDef");
            CreateIndex("LookUp.PaintColour", "PaintCategoryId");
            AddForeignKey("LookUp.PaintColour", "PaintCategoryId", "LookUp.PaintCategory", "PaintCategoryId", cascadeDelete: true);
        }
    }
}
