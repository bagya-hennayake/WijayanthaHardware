using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{
    [Table("PaintSubCategory", Schema = "LookUp")]
    public class PaintSubCategory
    {
        [Key]
        public int PaintSubCategoryId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

    }
}