using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.Entities
{
    [Table("PaintCategory", Schema = "LookUp")]
    public class PaintCategory
    {
        [key]
        public int PaintCategoryId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }

    }
}