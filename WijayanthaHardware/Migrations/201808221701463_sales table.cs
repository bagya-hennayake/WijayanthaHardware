namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salestable : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "Sales.Sales", newSchema: "Master");
            AddColumn("Master.Sales", "SalesDescription", c => c.String());
            AddColumn("Master.Sales", "SaleDate", c => c.DateTime(nullable: false));
            AddColumn("Master.Sales", "SaleValue", c => c.String());
            DropColumn("Master.Sales", "SalesDate");
            DropColumn("Master.Sales", "SalesTimes");
            DropColumn("Master.Sales", "SalesAmount");
            DropColumn("Master.Sales", "SalesPId");
            DropColumn("Master.Sales", "SalesPWId");
        }
        
        public override void Down()
        {
            AddColumn("Master.Sales", "SalesPWId", c => c.Int(nullable: false));
            AddColumn("Master.Sales", "SalesPId", c => c.Int(nullable: false));
            AddColumn("Master.Sales", "SalesAmount", c => c.String());
            AddColumn("Master.Sales", "SalesTimes", c => c.DateTime(nullable: false));
            AddColumn("Master.Sales", "SalesDate", c => c.DateTime(nullable: false));
            DropColumn("Master.Sales", "SaleValue");
            DropColumn("Master.Sales", "SaleDate");
            DropColumn("Master.Sales", "SalesDescription");
            MoveTable(name: "Master.Sales", newSchema: "Sales");
        }
    }
}
