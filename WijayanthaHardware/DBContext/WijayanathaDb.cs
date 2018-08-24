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
        public DbSet<PaintCategory> PaintCategory { get; set; }
        public DbSet<PaintSubCategory> PaintSubCategory { get; set; }
        public DbSet<PaintMaster> PaintMaster { get; set; }
        public DbSet<PaintColour> PaintColour { get; set; }
        public DbSet<PaintVolume> PaintVolume { get; set; }
        public DbSet<PowerToolCategory> PowerToolCategory { get; set; }
        public DbSet<PowerToolSubCatogery> PowerToolSubCatogery { get; set; }
        public DbSet<PowerToolMaster> PowerToolMaster { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Sales> Sales { get; set; }



    }
}