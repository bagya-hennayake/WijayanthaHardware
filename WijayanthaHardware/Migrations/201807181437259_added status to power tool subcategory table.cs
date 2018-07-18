namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstatustopowertoolsubcategorytable : DbMigration
    {
        public override void Up()
        {
            AddColumn("LookUp.PowerToolSubCatogery", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("LookUp.PowerToolSubCatogery", "Status");
        }
    }
}
