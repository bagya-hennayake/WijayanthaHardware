namespace WijayanthaHardware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class volume_lookup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "LookUp.Volume",
                c => new
                    {
                        VolumeId = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.VolumeId);
            
        }
        
        public override void Down()
        {
            DropTable("LookUp.Volume");
        }
    }
}
