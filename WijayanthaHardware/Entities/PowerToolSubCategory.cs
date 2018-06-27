using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{
    [Table("PowerToolSubCategory", Schema = "LookUp")]

    public class PowerToolSubCategory
    {
        [Key]
        public int PowerToolSubCategoryId { get; set; }
        // full names use kaapag
        public string Model { get; set; }
        public string Detail { get; set; }
        public PowerToolsCategory PowerToolsCategory { get; set; }
        public int PowerToolCategoryId { get; set; }
    }
}