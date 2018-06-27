namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableEdited : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "LookUp.Volume", newName: "PaintVolume");
        }
        
        public override void Down()
        {
            RenameTable(name: "LookUp.PaintVolume", newName: "Volume");
        }
    }
}
