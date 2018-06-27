namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaintColourforce : DbMigration
    {
        public override void Up()
        {
            DropColumn("LookUp.PaintColour", "PCategory_1");
        }
        
        public override void Down()
        {
            AddColumn("LookUp.PaintColour", "PCategory_1", c => c.Int(nullable: false));
        }
    }
}
