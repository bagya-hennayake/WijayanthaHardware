namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstatustoPowerToolCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("LookUp.PowerToolCategory", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("LookUp.PowerToolCategory", "Status");
        }
    }
}
