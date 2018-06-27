using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{
    [Table("PaintColour", Schema = "LookUp")]
    public class PaintColour
    {
        [Key]
        public int PaintColourId { get; set; }
        public PaintCategoryDef PaintCategoryDef { get; set; }
      
       
        public string Colour { get; set; }
        public string ColourCode { get; set; }

       
    }
}