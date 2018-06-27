namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category_lookup : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("LookUp.Category");
        }
    }
}
