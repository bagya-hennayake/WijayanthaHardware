using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{
    [Table("PowerToolMaster", Schema = "Inventory")]
    public class PowerToolMaster
    {
        [Key]
        public int PowerToolMasterId { get; set; }

        public int Quantity { get; set; }
        public PowerToolSubCategory PowerToolSubCategory { get; set; }

        public int PowerToolCategoryId { get; set; }






    }
}