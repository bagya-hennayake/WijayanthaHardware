namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class created_powerToolsCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "LookUp.PowerToolSubCategory",
                c => new
                    {
                        PowerToolSubCategoryId = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Detail = c.String(),
                        PowerToolCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PowerToolSubCategoryId)
                .ForeignKey("LookUp.PowerToolsCategory", t => t.PowerToolCategoryId, cascadeDelete: true)
                .Index(t => t.PowerToolCategoryId);
            
            AddColumn("LookUp.PowerToolsCategory", "Value", c => c.String());
            AddColumn("LookUp.PowerToolsCategory", "Details", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("LookUp.PowerToolSubCategory", "PowerToolCategoryId", "LookUp.PowerToolsCategory");
            DropIndex("LookUp.PowerToolSubCategory", new[] { "PowerToolCategoryId" });
            DropColumn("LookUp.PowerToolsCategory", "Details");
            DropColumn("LookUp.PowerToolsCategory", "Value");
            DropTable("LookUp.PowerToolSubCategory");
        }
    }
}
