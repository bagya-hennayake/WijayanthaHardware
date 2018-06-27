namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class matertableadded1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("LookUp.PaintSubCategory", "PaintCategoryId", "LookUp.PaintCategory");
            DropIndex("LookUp.PaintSubCategory", new[] { "PaintCategoryId" });
            AddColumn("Inventory.PaintMaster", "PaintCategoryId", c => c.Int(nullable: false));
            CreateIndex("Inventory.PaintMaster", "PaintCategoryId");
            AddForeignKey("Inventory.PaintMaster", "PaintCategoryId", "LookUp.PaintCategory", "PaintCategoryId", cascadeDelete: true);
            DropColumn("LookUp.PaintSubCategory", "PaintCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("LookUp.PaintSubCategory", "PaintCategoryId", c => c.Int(nullable: false));
            DropForeignKey("Inventory.PaintMaster", "PaintCategoryId", "LookUp.PaintCategory");
            DropIndex("Inventory.PaintMaster", new[] { "PaintCategoryId" });
            DropColumn("Inventory.PaintMaster", "PaintCategoryId");
            CreateIndex("LookUp.PaintSubCategory", "PaintCategoryId");
            AddForeignKey("LookUp.PaintSubCategory", "PaintCategoryId", "LookUp.PaintCategory", "PaintCategoryId", cascadeDelete: true);
        }
    }
}
