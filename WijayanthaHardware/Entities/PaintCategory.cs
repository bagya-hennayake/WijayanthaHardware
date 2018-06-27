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
        public int PaintCategryId { get; set; }
        public string PaintCategoryName { get; set; }

        public PaintCategoryDef PaintCategoryDef
        { get; set; }
        public int PaintDefLevel { get; set; }

    }
}