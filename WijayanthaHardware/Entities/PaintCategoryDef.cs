using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{
    [Table("PaintCategoryDef", Schema = "LookUp")]//LookUp.Category
    public class PaintCategoryDef
    {
        [Key]
        public int PaintDefLevel { get; set; }
        public string PaintDefName { get; set; }
        
    }
}