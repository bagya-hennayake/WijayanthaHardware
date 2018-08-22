namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sales1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Sales.Sales",
                c => new
                    {
                        SalesId = c.Int(nullable: false, identity: true),
                        SalesDate = c.DateTime(nullable: false),
                        SalesTimes = c.DateTime(nullable: false),
                        SalesAmount = c.String(),
                        SalesPId = c.Int(nullable: false),
                        SalesPWId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesId);
            
        }
        
        public override void Down()
        {
            DropTable("Sales.Sales");
        }
    }
}
