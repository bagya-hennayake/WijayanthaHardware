using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{[Table("PowerToolMaster",Schema = "Inventory")]
    public class PowerToolMaster
    {[key]
        public int PowerToolMasterId { get; set; }
        public PowerToolCategory PowerToolCategory { get; set; }
        public int PowerToolCategoryId { get; set; }
        public PowerToolSubCatogery PowerToolSubCatogery { get; set; }
        public int PowerToolSubCatogeryId { get; set; }
        public string Detail { get; set; }
        public int Quantity { get; set; }
    }
}