namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class powertoolkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("LookUp.PowerToolSubCatogery", "PowerToolCategoryId", c => c.Int());
            CreateIndex("LookUp.PowerToolSubCatogery", "PowerToolCategoryId");
            AddForeignKey("LookUp.PowerToolSubCatogery", "PowerToolCategoryId", "LookUp.PowerToolCategory", "PowerToolCategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("LookUp.PowerToolSubCatogery", "PowerToolCategoryId", "LookUp.PowerToolCategory");
            DropIndex("LookUp.PowerToolSubCatogery", new[] { "PowerToolCategoryId" });
            DropColumn("LookUp.PowerToolSubCatogery", "PowerToolCategoryId");
        }
    }
}
