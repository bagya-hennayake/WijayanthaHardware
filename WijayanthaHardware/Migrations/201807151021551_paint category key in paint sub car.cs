namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paintcategorykeyinpaintsubcar : DbMigration
    {
        public override void Up()
        {
            AddColumn("LookUp.PaintSubCategory", "PaintCategoryId", c => c.Int());
            CreateIndex("LookUp.PaintSubCategory", "PaintCategoryId");
            AddForeignKey("LookUp.PaintSubCategory", "PaintCategoryId", "LookUp.PaintCategory", "PaintCategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("LookUp.PaintSubCategory", "PaintCategoryId", "LookUp.PaintCategory");
            DropIndex("LookUp.PaintSubCategory", new[] { "PaintCategoryId" });
            DropColumn("LookUp.PaintSubCategory", "PaintCategoryId");
        }
    }
}
