using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WijayanthaHardware.Entities;

namespace WijayanthaHardware.DBContext
{
    public class WijayanathaDb : DbContext
    {
        public WijayanathaDb() : base("wijayanthacontext") { }

        public DbSet<PaintCategoryDef> PaintCategory { get; set; }
        public DbSet<PaintVolume> PaintVolume { get; set; }
        public DbSet<PowerToolsCategory> PowerToolsCategory { get; set; }
        public DbSet<PaintColour> PaintColour { get; set; }
        public DbSet<PaintMaster> PaintMaster { get; set; }

        public DbSet<PowerToolSubCategory> PowerToolSubCategory { get; set; }

        public DbSet<PowerToolMaster> PowerToolMaster { get; set; }
    }
}