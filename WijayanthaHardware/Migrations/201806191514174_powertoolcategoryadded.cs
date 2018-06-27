namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class powertoolcategoryadded : DbMigration
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
                "LookUp.PowerToolsCategory",
                c => new
                    {
                        PowerToolCategoryId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.PowerToolCategoryId);
            
            DropTable("LookUp.Category");
        }
        
        public override void Down()
        {
            CreateTable(
                "LookUp.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            DropTable("LookUp.PowerToolsCategory");
            DropTable("LookUp.PaintCategory");
        }
    }
}
