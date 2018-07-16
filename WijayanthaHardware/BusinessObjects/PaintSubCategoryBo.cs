using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WijayanthaHardware.BusinessObjects
{
    public class PaintSubCategoryBo
    {
        public int PaintSubCategoryId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int? PaintCategoryId { get; set; }
    }
}