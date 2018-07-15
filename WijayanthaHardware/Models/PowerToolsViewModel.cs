using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WijayanthaHardware.Models
{
    public class PowerToolsViewModel
    {
        public int PowerToolId { get; set; }
        public SelectList PowerToolSelectList { get; set; }
        public int? PowerToolSubCategoryId { get; set; }
        public SelectList PowerToolSubSelectList { get; set; }
    }
}